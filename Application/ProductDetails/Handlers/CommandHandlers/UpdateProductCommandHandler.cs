using Application.DescriptionDetails.Commands.Request;
using Application.ProductDetails.Commands.Request;
using Application.ProductDetails.Commands.Response;
using AutoMapper;
using Core.Helpers;
using Domain.Entities;
using Domain.IRepositories;
using MediatR;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ProductDetails.Handlers.CommandHandlers
{
    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommandRequest, UpdateProductCommandResponse>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;
        private readonly IHostEnvironment _env;
        private readonly IColorRepository _colorRepository;


        public UpdateProductCommandHandler(IProductRepository productRepository, IMapper mapper, IHostEnvironment env, IColorRepository colorRepository)
        {
            _productRepository = productRepository;
            _mapper = mapper;
            _env = env;
            _colorRepository = colorRepository;
        }

        public async Task<UpdateProductCommandResponse> Handle(UpdateProductCommandRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var existingProduct = _productRepository.Get(x => x.Id == request.Id, "ProductSizes.Size", "ProductTags.Tag", "ProductColors.Color", "ProductImages", "Description", "Description.DescriptionImages");

                if (existingProduct == null)
                {
                    return new UpdateProductCommandResponse
                    {
                        IsSuccess = false,
                        ErrorMessage = $"Product with Id {request.Id} not found."
                    };
                }

                _mapper.Map(request, existingProduct);

                existingProduct.ProductTags.Clear(); 
                if (request.TagIds != null && request.TagIds.Any())
                {
                    existingProduct.ProductTags = request.TagIds.Select(tagId => new ProductTag
                    {
                        TagId = tagId
                    }).ToList();
                }

                // Update sizes
                existingProduct.ProductSizes.Clear(); 
                if (request.SizeIds != null && request.SizeIds.Any())
                {
                    existingProduct.ProductSizes = request.SizeIds.Select(sizeId => new ProductSize
                    {
                        SizeId = sizeId
                    }).ToList();
                }

                existingProduct.Description.Introduction = request.Description.Introduction;

                // Açıklamaya ait eski resimleri sil ve yeni resimleri ekle
                foreach (var existingImage in existingProduct.Description.DescriptionImages.ToList())
                {
                    FileManager.Delete(_env.ContentRootPath, "uploads/descriptions", existingImage.Image);
                    existingProduct.Description.DescriptionImages.Remove(existingImage);
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
                        existingProduct.Description.DescriptionImages.Add(descriptionImage);
                    }
                }
                else
                {
                    existingProduct.Description.DescriptionImages.Clear();
                }

                if (request.ColorImages != null && request.ColorImages.Any())
                {
                    // Önceki renkli resimleri temizle
                    existingProduct.ProductImages?.Clear();

                    foreach (var colorImageRequest in request.ColorImages)
                    {
                        Color color = await _colorRepository.GetByIdAsync(colorImageRequest.ColorId);

                        if (color != null)
                        {
                            foreach (var file in colorImageRequest.ImageFiles)
                            {
                                string fileName = FileManager.Save(file, _env, "uploads/products");

                                ProductImage productImage = new ProductImage
                                {
                                    Image = fileName,
                                    Color = color
                                };

                                existingProduct.ProductImages ??= new List<ProductImage>();
                                existingProduct.ProductImages.Add(productImage);
                            }
                        }
                    }
                }

                await _productRepository.UpdateAsync(existingProduct);
                await _productRepository.CommitAsync();

                return new UpdateProductCommandResponse
                {
                    IsSuccess = true
                };
            }
            catch (Exception ex)
            {
                return new UpdateProductCommandResponse
                {
                    IsSuccess = false,
                    ErrorMessage = $"An error occurred while updating the product: {ex.Message}"
                };
            }
        }
    }
}
