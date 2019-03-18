using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace WebEncryptor.Controllers
{
    public class HidorController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}