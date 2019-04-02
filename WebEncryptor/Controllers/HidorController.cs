using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace WebEncryptor.Controllers
{
    public class HidorController : Controller
    {
        public IActionResult Hidor()
        {
            return View();
        }

        public Bitmap HideText(Bitmap btm, String text)
        {
            Bitmap hidden = WebEncryptor.Helpers.Hidor.embedText(text, btm);
            return hidden;
        }

        public String ExtractText(Bitmap btm)
        {
            return WebEncryptor.Helpers.Hidor.extractText(btm);
        }
    }
}