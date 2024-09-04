using Microsoft.AspNetCore.Mvc;

namespace InCommPaymentWebApiCore.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        public async Task<> Index()
        {
            return View();
        }
    }
}
