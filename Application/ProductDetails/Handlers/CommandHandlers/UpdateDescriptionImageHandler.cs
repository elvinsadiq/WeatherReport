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
    public class UpdateDescriptionImageHandler : IRequestHandler<UpdateDescriptionImageRequest, UpdateProductCommandResponse>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;
        private readonly IHostEnvironment _env;


        public UpdateDescriptionImageHandler(IProductRepository productRepository, IMapper mapper, IHostEnvironment env)
        {
            _productRepository = productRepository;
            _mapper = mapper;
            _env = env;
        }
        public async Task<UpdateProductCommandResponse> Handle(UpdateDescriptionImageRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var existingProduct = _productRepository.Get(x => x.Id == request.Id, "Description.DescriptionImages");

                if (existingProduct == null)
                {
                    return new UpdateProductCommandResponse
                    {
                        IsSuccess = false,
                        ErrorMessage = $"Product with Id {request.Id} not found."
                    };
                }

                // Clear existing description images
                foreach (var existingImage in existingProduct.Description.DescriptionImages.ToList())
                {
                    FileManager.Delete(_env.ContentRootPath, "uploads/descriptions", existingImage.Image);
                    existingProduct.Description.DescriptionImages.Remove(existingImage);
                }

                // Add new description images
                if (request.ImageFiles != null && request.ImageFiles.Any())
                {
                    foreach (var file in request.ImageFiles)
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
                    ErrorMessage = $"An error occurred while updating the description images: {ex.Message}"
                };
            }
        }
    }
}
