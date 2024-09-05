using InCommPayment.Application.Interfaces;
using InCommPayment.Domain.Model;
using InCommPaymentWebApiCore.Model;
using Microsoft.AspNetCore.Mvc;

namespace InCommPaymentWebApiCore.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        public readonly IAppServiceProduct _appServiceProduct;
        public ProductController(IAppServiceProduct appServiceProduct)
        {
            _appServiceProduct = appServiceProduct;
        }

        [HttpGet]
        [Route("getproductbyid/{productId}")]
        public async Task<Response<Product>> GetProductById(string productId)
        {
            try
            {
                var listProducts = new List<Product>();
                var result = await _appServiceProduct.Get(productId);

                if (result == null)
                {
                    return new Response<Product>()
                    {
                        message = "product not found",
                        returnType = ReturnType.NotFound
                    };
                }

                listProducts.Add(result);

                return new Response<Product>()
                {
                    message = "product found",
                    returnType = ReturnType.NotFound,
                    returnedValue = listProducts
                };
            }
            catch (Exception ex)
            {
                return new Response<Product>()
                {
                    message = ex.Message,
                    returnType = ReturnType.InternalError
                };
            }
        }

        [HttpGet]
        [Route("getallproducts")]
        public async Task<Response<Product>> GetAllProducts()
        {
            try
            {
                var result = await _appServiceProduct.GetAll();

                if (result == null)
                {
                    return new Response<Product>()
                    {
                        message = "products list is empty",
                        returnType = ReturnType.NotFound
                    };
                }

                return new Response<Product>()
                {
                    message = "products found",
                    returnType = ReturnType.Success,
                    returnedValue = result
                };
            }
            catch (Exception ex)
            {
                return new Response<Product>()
                {
                    message = ex.Message,
                    returnType = ReturnType.InternalError
                };
            }
        }

        [HttpPost]
        [Route("addallproducts")]
        public async Task<Response<Product>> AddAllProducts(List<Product>? listProducts)
        {
            try
            {
                //List<Product>? listProducts = null;
                if(listProducts == null)
                {
                    listProducts = new List<Product>()
                    {
                        new Product()
                        {
                            Id = Guid.NewGuid().ToString(),
                            Name = "Product 1",
                            Description = "Description Product 1",
                            Price = 100,
                            Quantity = 10
                        },
                        new Product()
                        {
                            Id = Guid.NewGuid().ToString(),
                            Name = "Product 2",
                            Description = "Description Product 2",
                            Price = 50,
                            Quantity = 100
                        },
                        new Product()
                        {
                            Id = Guid.NewGuid().ToString(),
                            Name = "Product 3",
                            Description = "Description Product 3",
                            Price = 99,
                            Quantity = 10
                        },
                        new Product()
                        {
                            Id = Guid.NewGuid().ToString(),
                            Name = "Product 4",
                            Description = "Description Product 4",
                            Price = 150,
                            Quantity = 40
                        },

                    };

                    _appServiceProduct.AddAll(listProducts);
                    return new Response<Product>()
                    {
                        message = "Added successfully",
                        returnType = ReturnType.Success
                    };
                }
                else
                {
                    _appServiceProduct.AddAll(listProducts);
                    return new Response<Product>()
                    {
                        message = "Added successfully",
                        returnType = ReturnType.Success
                    };
                }
            }
            catch (Exception ex)
            {
                return new Response<Product>()
                {
                    message = ex.Message,
                    returnType = ReturnType.InternalError
                };
            }
        }
    }
}
