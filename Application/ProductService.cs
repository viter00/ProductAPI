using AutoMapper;
using Core.Interfaces;
using Core.Models.Data;
using Core.Models.DTO;
using Core.Models.Endpoints.Insert;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
    public class ProductService : IProductService
    {
        private readonly IBaseRepository<Product> _productRepository;
        IMapper _mapper;
        public ProductService(IBaseRepository<Product> baseRepository, IMapper mapper)
        {
            _productRepository = baseRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ProductDto>> GetAllProductsAsync()
        {
            var product = await _productRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<ProductDto>>(product);
        }

        public async Task<ProductDto> GetProductByIdAsync(int id)
        {
            var product = await _productRepository.GetByIdAsync(id);
            return _mapper.Map<ProductDto>(product);
        }

        public async Task<ProductDto> AddProductAsync(RequestInsert product)
        {
            var productData = _mapper.Map<Product>(product);
            var insert = await _productRepository.AddAsync(productData);
            return _mapper.Map<ProductDto>(insert);
        }

        public async Task<ProductDto> UpdateProductAsync(ProductDto product)
        {
            var productData = _mapper.Map<Product>(product);
            var update = await _productRepository.UpdateAsync(productData);
            return _mapper.Map<ProductDto>(update);
        }

        public async Task<ProductDto> DeleteProductAsync(int id)
        {
            var product = await _productRepository.DeleteAsync(id);
            return _mapper.Map<ProductDto>(product);
        }
    }
}

