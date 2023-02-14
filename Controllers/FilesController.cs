using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Raindish.Models;

namespace Raindish.Controllers
{
    public class FilesController : Controller
    {
        Microsoft.AspNetCore.Hosting.IWebHostEnvironment _hostingEnvironment = null;

        public FilesController(Microsoft.AspNetCore.Hosting.IWebHostEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }
        [HttpGet]
        public IActionResult Index(string fileName ="")
        {
            FileClass fileObj = new FileClass();
            fileObj.Name = fileName;
            string path = $"{_hostingEnvironment.WebRootPath}\\files\\";
            int nId = 1;

            foreach(string pdfPath in Directory.EnumerateFiles(path, "*.pdf"))
            {
                fileObj.Files.Add(new FileClass()
                {
                    FileId = nId++,
                    Name = Path.GetFileName(pdfPath),
                    Path = pdfPath
                });
            }
            return View(fileObj);
        }

        [HttpPost]
        public IActionResult Index(IFormFile file, [FromServices] Microsoft.AspNetCore.Hosting.IWebHostEnvironment hostingEnvironment)
        {
            string fileName = $"{hostingEnvironment.WebRootPath}\\Files\\{file.FileName}";
            using (FileStream fileStream = System.IO.File.Create(fileName))
            {
                file.CopyTo(fileStream);
                fileStream.Flush();
            }
            return Index();
        }
        public IActionResult PDFViewerNewTab(string fileName)
        {
            string path = _hostingEnvironment.WebRootPath+ "\\files\\" + fileName;
            return File(System.IO.File.ReadAllBytes(path), "application/pdf");
        }
    }
}
