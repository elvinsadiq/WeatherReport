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
    public class UpdateProductImageCommandHandler : IRequestHandler<UpdateProductColorImageRequest, UpdateProductCommandResponse>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;
        private readonly IHostEnvironment _env;
        private readonly IColorRepository _colorRepository;


        public UpdateProductImageCommandHandler(IProductRepository productRepository, IMapper mapper, IHostEnvironment env, IColorRepository colorRepository)
        {
            _productRepository = productRepository;
            _mapper = mapper;
            _env = env;
            _colorRepository = colorRepository;
        }

        public async Task<UpdateProductCommandResponse> Handle(UpdateProductColorImageRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var existingProduct = _productRepository.Get(x => x.Id == request.Id, "ProductImages");

                if (existingProduct == null)
                {
                    return new UpdateProductCommandResponse
                    {
                        IsSuccess = false,
                        ErrorMessage = $"Product with Id {request.Id} not found."
                    };
                }

                // Clear existing images

                //foreach (var item in existingProduct.ProductImages)
                //{
                //    if(request.ColorId == item.ColorId)
                //    {
                //        existingProduct.ProductImages.Remove(item);
                //    }
                //}

                existingProduct.ProductImages.RemoveAll(item => item.ColorId == request.ColorId);

                //existingProduct.ProductImages?.Clear();

                if (request.ImageFiles != null && request.ImageFiles.Any())
                {
                    foreach (var file in request.ImageFiles)
                    {
                        string fileName = FileManager.Save(file, _env, "uploads/products");

                        ProductImage productImage = new ProductImage
                        {
                            Image = fileName,
                            ColorId = request.ColorId  // Assuming ColorId is part of the request
                        };

                        existingProduct.ProductImages ??= new List<ProductImage>();
                        existingProduct.ProductImages.Add(productImage);
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
                    ErrorMessage = $"An error occurred while updating the product images: {ex.Message}"
                };
            }
        }
    }
}
