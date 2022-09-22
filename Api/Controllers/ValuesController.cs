using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DI.Domain.Entity;
using DI.Domain.IServices;
using Microsoft.AspNetCore.Mvc;

namespace CarAdminNetCore.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        private IServiceCarImage ServiceCarImage;

        public ValuesController(IServiceCarImage serviceCarImage)
        {
            this.ServiceCarImage = serviceCarImage;
        }

        // GET api/values
        [HttpGet]
        public async Task<List<CarImage>> Get()
        {
            return await this.ServiceCarImage.Get();
        }
    }
}
