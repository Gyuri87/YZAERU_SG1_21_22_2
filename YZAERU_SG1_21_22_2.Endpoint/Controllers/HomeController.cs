using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace YZAERU_SG1_21_22_2.Endpoint.Controllers
{
    [Route("")]
    public class HomeController : Controller
    {
        [HttpGet]
        [ActionName("")]
        public string Index()
        {
            return "Helló Lécsibesz!";
        }
    }
}
