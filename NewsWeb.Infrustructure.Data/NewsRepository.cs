using Microsoft.EntityFrameworkCore;
using NewsWeb.Core.Contracts;
using NewsWeb.Core.Entities;
using NewsWeb.Infraustraucture.EF;
using System.Collections.Generic;
using System.Linq;

namespace NewsWeb.Infrustructure.Data
{
    public class NewsRepository : INewsRepository
    {
        private readonly MyContext Context;
        public NewsRepository(MyContext Context)
        {
            this.Context = Context;
        }
        public List<News> GetHottestNews(int count)
        {
            return Context.News.OrderByDescending(a => a.PubDate).Take(3).ToList();
        }
        public List<News> HomeSearch(string search)
        {
            return Context.News.Where(a => a.Title.Contains(search) || a.Summary.Contains(search)).ToList();
        }
        public News Get(int id)
        {
            return Context.News.Find(id);
        }
        public List<News> GetAll()
        {
            return Context.News.ToList();
        }
        public void CreateNews(News news)
        {
            Context.Add(news);
            Context.SaveChanges();
        }
        public void Delete(int id)
        {
            Context.News.Remove(new News() { NewsId = id });
            Context.SaveChanges();
        }
        public dynamic NewsDetails(int id)
        {
            return Context.News.Find(id);
        }
        public List<News> FindByCategory(int categoryId)
        {
            return Context.News.Include(a => a.Category)
                .Where(a => a.CategoryId == categoryId).ToList();
        }
    }
}
