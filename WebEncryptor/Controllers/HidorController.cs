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

        Bitmap btm = null;

        public IActionResult Hidor()
        {
            return View();
        }


        // Implement https://github.com/paw3lx/StegoCore
        [HttpPost("UploadImage")]
        public async Task<IActionResult> Upload(List<ImageFile> files)
        {
            long size = files.Sum(f => f.Length);

            // full path to file in temp location
            var filePath = Path.GetTempFileName();

            foreach (var formFile in files)
            {
                if (formFile.Length > 0)
                {
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await formFile.CopyToAsync(stream);
                    }
                }
            }

            // process uploaded files
            // Don't rely on or trust the FileName property without validation.

           // btm = ConvertToBitmap(filePath.ToString());  //Use Stegocore??

            return RedirectToAction("Hidor"); //How to remain on same page? Return CONTENT == Upload COmplete???
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

        public Bitmap ConvertToBitmap(string fileName)
        {
            Bitmap bitmap;
            using (Stream bmpStream = System.IO.File.Open(fileName, System.IO.FileMode.Open))
            {
                Image image = Image.FromStream(bmpStream);

                bitmap = new Bitmap(image);

            }
            return bitmap;
        }
    }
}