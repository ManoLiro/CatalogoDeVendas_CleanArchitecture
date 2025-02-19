using AutoMapper;
using CleanArchMvc.Application.DTOs;
using CleanArchMvc.Application.Interfaces;
using CleanArchMvc.Application.Products.Commands;
using CleanArchMvc.Application.Products.Queries;
using CleanArchMvc.Domain.Entities;
using CleanArchMvc.Domain.Interfaces;
using MediatR;

namespace CleanArchMvc.Application.Services
{
    public class ProductService : IProductService
    {
        IMapper _mapper;
        private readonly IMediator _mediator;
        public ProductService(IMapper mapper,IMediator mediator)
        {
            _mapper = mapper;
            _mediator = mediator;
        }

        public async Task<IEnumerable<ProductDTO>> GetProducts()
        {
            var productsQuery = new GetProductsQuery();
            if (productsQuery == null)
            {
                throw new System.ArgumentNullException(nameof(productsQuery));
            }

            var result = await _mediator.Send(productsQuery);

            return _mapper.Map<IEnumerable<ProductDTO>>(result);
        }

        public async Task Add(ProductDTO productDto)
        {
            var productCreateCommand = _mapper.Map<ProductCreateCommand>(productDto);
            await _mediator.Send(productCreateCommand);
        }

        public async Task<ProductDTO> GetById(int? id)
        {
            var ProductQuery = new GetProductByIdQuery(id.Value);
            if (ProductQuery == null)
            {
                throw new System.ArgumentNullException(nameof(ProductQuery));
            }

            var result = await _mediator.Send(ProductQuery);

            return _mapper.Map<ProductDTO>(result);
        }

        //public async Task<ProductDTO> GetProductCategory(int? id)
        //{
        //    var ProductQuery = new GetProductByIdQuery(id.Value);
        //    if (ProductQuery == null)
        //    {
        //        throw new System.ArgumentNullException(nameof(ProductQuery));
        //    }

        //    var result = await _mediator.Send(ProductQuery);

        //    return _mapper.Map<ProductDTO>(result);
        //}

        public async Task Remove(int? id)
        {
            var productRemoveCommand = new ProductRemoveCommand(id.Value);
            if (productRemoveCommand == null)
            {
                throw new System.ArgumentNullException(nameof(productRemoveCommand));
            }
            await _mediator.Send(productRemoveCommand);
        }

        public async Task Update(ProductDTO productDto)
        {
            var productUpdateCommand = _mapper.Map<ProductUpdateCommand>(productDto);
            await _mediator.Send(productUpdateCommand);
        }
    }
}
