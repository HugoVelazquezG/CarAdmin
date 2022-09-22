using System.Threading.Tasks;
using DI.Domain.IServices;
using Microsoft.AspNetCore.Mvc;

namespace CarAdminNetCore.Controllers
{
    /// <summary>
    /// Controller to add initial information
    /// </summary>
    [Route("api/[controller]")]
    public class LoadInfoController : Controller
    {
        /// <summary>
        /// Load Information Service
        /// </summary>
        private IServiceLoadInformation ServiceLoadInformation;

        /// <summary>
        /// Load Information controller constructor
        /// </summary>
        /// <param name="serviceLoadInformation"></param>
        public LoadInfoController(IServiceLoadInformation serviceLoadInformation)
        {
            this.ServiceLoadInformation = serviceLoadInformation;
        }

        /// <summary>
        /// Adding initial information
        /// </summary>
        /// <returns>Returns Flag</returns>
        [HttpPost]
        public async Task<IActionResult> Get()
        {
            try
            {
                var result = await this.ServiceLoadInformation.LoadInitialInformation();

                return this.Ok(result);
            }
            catch (System.Exception ex)
            {
                return StatusCode(500);
            }
            
        }
    }
}