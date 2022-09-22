using DI.Domain.IServices;
using Microsoft.AspNetCore.Mvc;

namespace CarAdmin.Controllers
{
    public class CarImageController : Controller
    {
        private readonly IServiceCarImage serviceCarImage;

        public CarImageController(IServiceCarImage serviceCarImage)
        {
            this.serviceCarImage = serviceCarImage;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await serviceCarImage.Get();
            return Ok(result);
        }
    }
}
