using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebEncryptor.Models;

namespace WebEncryptor.Controllers
{
    public class HidorController : Controller
    {

        Bitmap btm;

        public IActionResult Hidor()
        {
            return View();
        }

        public async void Upload(ImageFile image)
        {
            if (ModelState.IsValid)
            {
                if (image != null && image.Length > 0)
                {
                    var fileName = Path.GetFileName(image.FileName);
                    var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\uploads", fileName);
                    using (var fileSteam = new FileStream(filePath, FileMode.Create))
                    {
                        await image.CopyToAsync(fileSteam);
                    }
                    btm = new Bitmap(filePath);
                }
            }
        }

        public Bitmap HideText(String text)
        {
            Bitmap hidden = WebEncryptor.Helpers.Hidor.embedText(text, btm);
            return hidden;
        }

        public String ExtractText()
        {
            return WebEncryptor.Helpers.Hidor.extractText(btm);
        }
    }
}