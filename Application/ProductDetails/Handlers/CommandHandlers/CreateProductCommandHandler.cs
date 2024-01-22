using Application.ProductDetails.Commands.Request;
using Application.ProductDetails.Commands.Response;
using Application.ProductDetails.Handlers.CommandHandlers;
using AutoMapper;
using Core.Helpers;
using Domain.Entities;
using Domain.IRepositories;
using MediatR;
using Microsoft.Extensions.Hosting;

public class CreateProductCommandHandler : IRequestHandler<CreateProductCommandRequest, CreateProductCommandResponse>
{
    private readonly IProductRepository _productRepository;
    private readonly IHostEnvironment _env;
    private readonly IMapper _mapper;
    private readonly IColorRepository _colorRepository;

    public CreateProductCommandHandler(IProductRepository productRepository, IMapper mapper, IHostEnvironment env, IColorRepository colorRepository)
    {
        _productRepository = productRepository;
        _mapper = mapper;
        _env = env;
        _colorRepository = colorRepository;
    }

    public async Task<CreateProductCommandResponse> Handle(CreateProductCommandRequest request, CancellationToken cancellationToken)
    {
        if (await _productRepository.IsExistAsync(x => x.Title == request.Title))
        {
            return new CreateProductCommandResponse
            {
                IsSuccess = false,
                ErrorMessage = "Title already exists!",
            };
        }

        var product = _mapper.Map<CreateProductCommandRequest, Product>(request);

        if (request.ColorImages != null && request.ColorImages.Any())
        {
            foreach (var colorImageRequest in request.ColorImages)
            {
                Color color = await _colorRepository.GetByIdAsync(colorImageRequest.ColorId);

                if (color != null)
                {
                    foreach (var file in colorImageRequest.ImageFiles)
                    {
                        string fileName = FileManager.Save(file, _env, "uploads/products");

                        // İçerik tipi IFormFile olarak belirtilmiş olduğundan
                        // aşağıdaki satırda bir hata alınmamalıdır.
                        ProductImage productImage = new ProductImage
                        {
                            Image = fileName,
                            Color = color
                        };

                        product.ProductImages ??= new List<ProductImage>();
                        product.ProductImages.Add(productImage);
                    }
                }
            }
        }



        if (request.TagIds != null && request.TagIds.Any())
        {
            product.ProductTags = request.TagIds.Select(tagId => new ProductTag
            {
                TagId = tagId
            }).ToList();
        }

        if (request.SizeIds != null && request.SizeIds.Any())
        {
            product.ProductSizes = request.SizeIds.Select(sizeId => new ProductSize
            {
                SizeId = sizeId
            }).ToList();
        }

        product.Description.Introduction = request.Description.Introduction;

        if (product.Description.DescriptionImages == null)
        {
            product.Description.DescriptionImages = new List<DescriptionImage>();
        }

        if (request.Description.ImageFiles != null && request.Description.ImageFiles.Any())
        {
            foreach (var file in request.Description.ImageFiles)
            {
                string fileName = FileManager.Save(file, _env, "uploads/descriptions");
                DescriptionImage descriptionImage = new DescriptionImage
                {
                    Image = fileName
                };
                product.Description.DescriptionImages.Add(descriptionImage);
            }
        }

        await _productRepository.AddAsync(product);
        await _productRepository.CommitAsync();

        return new CreateProductCommandResponse
        {
            IsSuccess = true
        };
    }
}
