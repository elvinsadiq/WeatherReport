using Application.DescriptionDetails.Commands.Request;
using Application.ProductDetails.Commands.Request;
using Application.ProductDetails.Commands.Response;
using Core.Helpers;
using Domain.IRepositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ProductDetails.Handlers.CommandHandlers
{
    public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommandRequest, DeleteProductCommandResponse>
    {
        private readonly IProductRepository _productRepository;


        public DeleteProductCommandHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<DeleteProductCommandResponse> Handle(DeleteProductCommandRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var productToDelete = await _productRepository.GetAsync(x => x.Id == request.Id);

                if (productToDelete == null)
                {
                    return new DeleteProductCommandResponse
                    {
                        IsSuccess = false,
                        ErrorMessage = $"Product with Id {request.Id} not found."
                    };
                }


                _productRepository.Remove(productToDelete);
                await _productRepository.CommitAsync();

                return new DeleteProductCommandResponse
                {
                    IsSuccess = true
                };
            }
            catch (Exception ex)
            {
                return new DeleteProductCommandResponse
                {
                    IsSuccess = false,
                    ErrorMessage = $"An error occurred while deleting the product: {ex.Message}"
                };
            }
        }
    }
}
