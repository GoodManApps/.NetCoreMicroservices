using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Actio.Services.Activities.Controllers
{
    [ApiController]
    [Route("")]
    public class HomeController: ControllerBase
    {
        public IActionResult Get() 
            => Content("Hello from Actio.Services.Activities!");
    }
}
