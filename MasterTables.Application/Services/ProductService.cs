﻿using MasterTables.Application.DTOs;
using MasterTables.Application.Interfaces;
using MasterTables.Domain.Exceptions;
using MediatR;
using MasterTables.Application.Commands;
using MasterTables.Application.Queries;

namespace MasterTables.Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IMediator _mediator;

        public ProductService(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<IEnumerable<ProductDto>> GetAllProductsAsync(CancellationToken cancellationToken)
        {
            try
            {
                var query = new GetAllProductsQuery();
                var result = await _mediator.Send(query, cancellationToken);
                return result;
            }
            catch (Exception ex)
            {
                // Log exception here
                throw new ApplicationException("An error occurred while retrieving products.", ex);
            }
        }

        public async Task<ProductDto> GetProductByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            try
            {
                var query = new GetProductByIdQuery(id);
                var result = await _mediator.Send(query, cancellationToken);
                if (result == null)
                {
                    throw new ProductNotFoundException($"Product with ID {id} not found.");
                }
                return result;
            }
            catch (ProductNotFoundException)
            {
                throw;
            }
            catch (Exception ex)
            {
                // Log exception here
                throw new ApplicationException("An error occurred while retrieving the product.", ex);
            }
        }

        public async Task<ProductDto> CreateProductAsync(CreateProductCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var command = new CreateProductCommand
                {
                    ProductName = request.ProductName,
                    Price = request.Price,
                    Code = request.Code,
                };
                var result = await _mediator.Send(command, cancellationToken);
                if (result == null)
                {
                    throw new ProductAlreadyExistsException("Product already exists.");
                }
                return result;
            }
            catch (ProductAlreadyExistsException)
            {
                throw; // rethrow the custom exception
            }
            catch (Exception ex)
            {
                // Log exception here
                throw new ApplicationException("An error occurred while creating the product.", ex);
            }
        }

        public async Task<ProductDto> UpdateProductAsync(UpdateProductCommand command, CancellationToken cancellationToken)
        {
            try
            {
                var result = await _mediator.Send(command, cancellationToken);
                if (result == null)
                {
                    throw new ProductNotFoundException("Product not found for update.");
                }
                return result;
            }
            catch (ProductNotFoundException)
            {
                throw; // rethrow the custom exception
            }
            catch (Exception ex)
            {
                // Log exception here
                throw;
            }
        }

        public async Task<bool> DeleteProductAsync(Guid id, CancellationToken cancellationToken)
        {
            try
            {
                var command = new DeleteProductCommand { Id = id };
                var result = await _mediator.Send(command, cancellationToken);
                if (!result)
                {
                    throw new ProductNotFoundException("Product not found for deletion.");
                }
                return result;
            }
            catch (ProductNotFoundException)
            {
                throw; // rethrow the custom exception
            }
            catch (Exception ex)
            {
                // Log exception here
                throw;
            }
        }
    }
}
