using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NewsWeb.Core.Entities;
using NewsWeb.Infrustructure.Data;
using NewsWeb.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace NewsWeb.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly NewsRepository Newsrepository;
        private readonly CategoryRepository Categoryrepository;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            Newsrepository = new NewsRepository();
            Categoryrepository = new CategoryRepository();
        }

        public IActionResult Index(int categoryId, string search)
        {
            List<News> news = new List<News>();
            if (!string.IsNullOrEmpty(search))
            {
                news = Newsrepository.Search(search);
            }
            else if (categoryId != 0)
            {
                news = Categoryrepository.Get(categoryId).News;
            }
            else
            {
                news = Newsrepository.GetHottestNews();
            }
            List<Category> categories = Categoryrepository.GetAll();
            List<CategoryViewModel> categoryViewModels = new List<CategoryViewModel>();
            foreach (var item in categories)
            {
                CategoryViewModel vm = new CategoryViewModel();
                vm.CategoryId = item.CategoryId;
                vm.Title = item.Title;
                vm.NewsCount = item.News.Count;
                categoryViewModels.Add(vm);
            }
            NewsViewModel model = new NewsViewModel()
            {
                News = news,
                Categories = categoryViewModels

            };
            ViewBag.Data = Categoryrepository.GetAll();
            return View(model);
        }
        public IActionResult NewsDetails(int id)
        {
            ViewBag.Data = Newsrepository.NewsDetails(id);
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
