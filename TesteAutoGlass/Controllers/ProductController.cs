using AutoMapper;
using Core.Exceptions;
using Core.Interfaces;
using Core.Models.Data;
using Core.Models.DTO;
using Core.Models.Endpoints;
using Core.Models.Endpoints.Insert;
using Core.Models.Endpoints.Update;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using System.Net.NetworkInformation;
using System.Threading.Tasks;

namespace TesteAutoGlass.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        IMapper _mapper;

        public ProductController(IProductService productService, IMapper mapper)
        {
            _productService = productService;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(typeof(ResponseList<Product>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Get(int pageNumber = 1, int pageSize = 10, bool? activated = null, string description = null )
        {
            try
            {
                var products = await _productService.GetAllProductsAsync() ?? throw new CustomException("Não existem produtos cadastrados");

                if (activated != null)
                {
                    string statusToFilter = (bool)activated ? "Ativo" : "Inativo";
                    products = products.Where(p => p.Status == statusToFilter);
                }

                if (!string.IsNullOrEmpty(description))
                {
                    products = products.Where(p => p.Description == description);
                }

                if (!products.Any())
                    throw new CustomException("Não existem produtos cadastrados");

                var productsPage = products
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToList();


                ResponseList<ProductDto> response = new()
                {
                    Data = productsPage.ToList(),
                    Pagination = new Pagination
                    {
                        Limit = pageSize,
                        Total = products.Count(),
                        Page = pageNumber
                    },
                    Success = true
                };
                return Ok(response);
            }
            catch (BaseException e)
            {
                ResponseError responseError = ResponseError.Get(false, e.Message);
                return StatusCode(StatusCodes.Status400BadRequest, responseError);
            }
            catch (Exception e)
            {
                ResponseError responseError = ResponseError.Get(false, e.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, responseError);
            }

        }

        [HttpGet("{productId}")]
        [ProducesResponseType(typeof(Response<Product>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetById(int productId)
        {
            try
            {
                if (productId <= 0)
                    throw new Exception("Requisição inválida");
                var existingProduct = await _productService.GetProductByIdAsync(productId) ?? throw new CustomException("Produto não encontrado");

                Response<ProductDto> response = new()
                {
                    Data = existingProduct,
                    Success = true
                };
                return Ok(response);
            }
            catch (BaseException e)
            {
                ResponseError responseError = ResponseError.Get(false, e.Message);
                return StatusCode(StatusCodes.Status400BadRequest, responseError);
            }
            catch (Exception e)
            {
                ResponseError responseError = ResponseError.Get(false, e.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, responseError);
            }

        }

        [HttpPost("Insert")]
        [ProducesResponseType(typeof(Response<Product>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Insert([FromBody] RequestInsert product)
        {
            try
            {
                product.Validate();
                var productData = await _productService.AddProductAsync(product);

                Response<ProductDto> response = new()
                {
                    Data = productData,
                    Success = true
                };
                return Ok(response);
            }
            catch (BaseException e)
            {
                ResponseError responseError = ResponseError.Get(false, e.Message);
                return StatusCode(StatusCodes.Status400BadRequest, responseError);
            }
            catch (Exception e)
            {
                ResponseError responseError = ResponseError.Get(false, e.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, responseError);
            }


        }


        [HttpPut("Update")]
        [ProducesResponseType(typeof(Response<Product>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Update([FromBody] RequestUpdate product)
        {
            try
            {
                product.Validate();
                var existingProduct = await _productService.GetProductByIdAsync(product.ProductId) ?? throw new CustomException("Produto não encontrado");
                var updatedProduct = _mapper.Map(product, existingProduct);
                var productData = await _productService.UpdateProductAsync(updatedProduct);

                Response<ProductDto> response = new()
                {
                    Data = productData,
                    Success = true
                };
                return Ok(response);
            }
            catch (BaseException e)
            {
                ResponseError responseError = ResponseError.Get(false, e.Message);
                return StatusCode(StatusCodes.Status400BadRequest, responseError);
            }
            catch (Exception e)
            {
                ResponseError responseError = ResponseError.Get(false, e.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, responseError);
            }

        }

        [HttpDelete("{productId}")]
        [ProducesResponseType(typeof(Response<Product>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Delete(int productId)
        {
            try
            {
                var existingProduct = await _productService.GetProductByIdAsync(productId) ?? throw new CustomException("Produto não encontrado");
                existingProduct.Status = "Inativo";
                var productData = await _productService.UpdateProductAsync(existingProduct);

                Response<ProductDto> response = new()
                {
                    Data = productData,
                    Success = true
                };
                return Ok(response);
            }
            catch (BaseException e)
            {
                ResponseError responseError = ResponseError.Get(false, e.Message);
                return StatusCode(StatusCodes.Status400BadRequest, responseError);
            }
            catch (Exception e)
            {
                ResponseError responseError = ResponseError.Get(false, e.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, responseError);
            }

        }

        
    }
}
