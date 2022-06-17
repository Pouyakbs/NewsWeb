using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NewsWeb.Core.Contracts;
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
        INewsFacade newsFacade;
        ICategoryFacade categoryFacade;
        ICommentFacade commentFacade;
        IUserAuthenticationFacade userAuthenticationFacade;
        public HomeController(ILogger<HomeController> logger, INewsFacade newsFacade, ICategoryFacade categoryFacade, ICommentFacade commentFacade, IUserAuthenticationFacade userAuthenticationFacade)
        {
            _logger = logger;
            this.newsFacade = newsFacade;
            this.categoryFacade = categoryFacade;
            this.commentFacade = commentFacade;
            this.userAuthenticationFacade = userAuthenticationFacade;
        }

        public IActionResult Index(int categoryId, string search)
        {
            IEnumerable<News> news = new List<News>();
            if (!string.IsNullOrEmpty(search))
            {
                news = newsFacade.HomeSearch(search);
            }
            else if (categoryId != 0)
            {
                news = newsFacade.FindByCategory(categoryId);
            }
            else
            {
                news = newsFacade.GetHottestNews(8);
            }
            IEnumerable<Category> categories = categoryFacade.GetAll();
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
            ViewBag.Data = categoryFacade.GetAll();
            return View(model);
        }
        public IActionResult NewsDetails(int id)
        {
            ViewBag.NewsList = newsFacade.GetAll();
            ViewBag.CategoryList = categoryFacade.GetAll();
            ViewBag.CommentData = commentFacade.GetComments().Where(c => c.NewsId == id).OrderByDescending(o => o.PubTime);
            ViewBag.Data = newsFacade.NewsDetails(id);
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult NewsDetails(Comment comment,News news , int id)
        {
            ViewBag.NewsList = newsFacade.GetAll();
            ViewBag.CategoryList = categoryFacade.GetAll();
            ViewBag.CommentData = commentFacade.GetComments().Where(c => c.NewsId == news.NewsId).OrderByDescending(o=>o.PubTime);
            ViewBag.Data = newsFacade.NewsDetails(id);
            Comment newscomment = new Comment()
            {
                Name = comment.Name,
                Email = comment.Email,
                CommentText = comment.CommentText,
                NewsId = news.NewsId,
                PubTime = DateTime.Now,
            };
            commentFacade.AddComment(newscomment);
            
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
