using Core.Models.Data;
using Core.Models.DTO;
using Core.Models.Endpoints.Insert;
using Core.Models.Endpoints.Update;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IProductService
    {
        Task<IEnumerable<ProductDto>> GetAllProductsAsync();
        Task<ProductDto> GetProductByIdAsync(int id);
        Task<ProductDto> AddProductAsync(Models.Endpoints.Insert.RequestInsert product);
        Task<ProductDto> UpdateProductAsync(ProductDto product);
        Task<ProductDto> DeleteProductAsync(int id);
    }
}
