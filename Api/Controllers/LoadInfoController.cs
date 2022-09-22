using DI.Domain.IServices;
using Microsoft.AspNetCore.Mvc;

namespace CarAdmin.Controllers
{
    public class LoadInfoController : Controller
    {
        private readonly IServiceLoadInformation serviceLoadInformation;

        public LoadInfoController(IServiceLoadInformation serviceLoadInformation)
        {
            this.serviceLoadInformation = serviceLoadInformation;
        }

        [HttpPost]
        public async Task<IActionResult> Get()
        {
            try
            {
                var result = await serviceLoadInformation.LoadInitialInformation();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return (StatusCode(500, ex));
            }
        }
    }
}
