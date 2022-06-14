using NewsWeb.Core.Entities;
using NewsWeb.Infraustraucture.EF;
using System.Collections.Generic;
using System.Linq;

namespace NewsWeb.Infrustructure.Data
{
    public class NewsRepository
    {
        private readonly MyContext Context;
        public NewsRepository()
        {
            Context = new MyContext();
        }
        public List<News> GetHottestNews()
        {
            return Context.News.OrderByDescending(a => a.PubDate).Take(3).ToList();
        }
        public List<News> Search(string search)
        {
            return Context.News.Where(a => a.Title.Contains(search) || a.Summary.Contains(search)).ToList();
        }
        public News News(int id)
        {
            return Context.News.Find(id);
        }
        public List<News> GetAll()
        {
            return Context.News.ToList();
        }
        public async void CreateNews(News news)
        {
            Context.Add(news);
            await Context.SaveChangesAsync();
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
    }
}
