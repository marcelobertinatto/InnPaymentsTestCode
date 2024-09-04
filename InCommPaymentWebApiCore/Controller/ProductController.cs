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
        [Route("/getAllProducts")]
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
                    message = "products list is empty",
                    returnType = ReturnType.NotFound,
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


    }
}
