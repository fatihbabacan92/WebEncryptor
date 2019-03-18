using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace WebEncryptor.Controllers
{
    public class DecryptorController : Controller
    {
        public IActionResult Decryptor()
        {
            return View();
        }

    }
}