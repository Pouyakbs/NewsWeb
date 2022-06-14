using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using NewsWeb.Core.Entities;
using NewsWeb.Infrustructure.Data;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace NewsWeb.Controllers
{
    public class NewsController : Controller
    {
        private readonly NewsRepository Newsrepository;
        private readonly CategoryRepository Categoryrepository;
        private readonly IWebHostEnvironment webHostEnvironment;
        public NewsController(IWebHostEnvironment HostEnvironment)
        {
            Newsrepository = new NewsRepository();
            Categoryrepository = new CategoryRepository();
            webHostEnvironment = HostEnvironment;
        }
        public IActionResult Index()
        {
            var validate = TempData.Peek("LoggedIn");
            if (validate == null || validate.ToString() == "False")
            {
                return RedirectToAction("login", "Account");
            }
            else
            {
                ViewBag.Data = Newsrepository.GetAll();
                return View();
            }
        }
        public IActionResult CreateNews()
        {
            var validate = TempData.Peek("LoggedIn");
            if (validate == null || validate.ToString() == "False")
            {
                return RedirectToAction("login", "Account");
            }
            else
            {
                return View();
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateNews(News model)
        {
            if (ModelState.IsValid)
            {
                string uniqueFileName = UploadedFile(model);
                News news = new News
                {
                    Title = model.Title,
                    CategoryId = model.CategoryId,
                    Text = model.Text,
                    Summary = model.Summary,
                    PubDate = model.PubDate,
                    NewsImages = uniqueFileName,
                };
                Newsrepository.CreateNews(news);
            }
            return RedirectToAction(nameof(Index));
        }
        private string UploadedFile(News news)
        {
            string uniqueFileName = null;

            if (news.Images != null)
            {
                string uploadsFolder = Path.Combine(webHostEnvironment.WebRootPath, "img");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + news.Images.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    news.Images.CopyTo(fileStream);
                }
            }
            return uniqueFileName;
        }
        public IActionResult CreateCategory()
        {
            var validate = TempData.Peek("LoggedIn");
            if (validate == null || validate.ToString() == "False")
            {
                return RedirectToAction("login", "Account");
            }
            else
            {
                return View();
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateCategory(Category category)
        {
            Categoryrepository.CreateCategory(category);
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Delete(int id)
        {
            var validate = TempData.Peek("LoggedIn");
            if (validate == null || validate.ToString() == "False")
            {
                return RedirectToAction("login", "Account");
            }
            else
            {
                Newsrepository.Delete(id);
                return RedirectToAction("index");
            }
        }
    }
}
