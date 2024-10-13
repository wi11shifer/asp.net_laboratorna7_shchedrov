using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Text;

namespace laboratorna7schedrov.Controllers
{
    public class FileController : Controller
    {
        [HttpGet]
        public IActionResult DownloadFile()
        {
            return View();
        }

        [HttpPost]
        public IActionResult DownloadFile(string firstName, string lastName, string fileName)
        {
            if (string.IsNullOrEmpty(fileName))
            {
                ModelState.AddModelError("", "File name can't be empty.");
                return View();
            }

            string content = $"Name: {firstName}\nSurame: {lastName}";

            var byteArray = Encoding.UTF8.GetBytes(content);
            var stream = new MemoryStream(byteArray);

            return File(stream, "text/plain", $"{fileName}.txt");
        }
    }
}
