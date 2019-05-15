using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace MvcCar.Controllers
{
    public class HELLOController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

       
    }
}