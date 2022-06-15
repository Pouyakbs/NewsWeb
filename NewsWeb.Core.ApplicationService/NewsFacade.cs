using NewsWeb.Core.Contracts;
using NewsWeb.Core.Entities;
using System;
using System.Collections.Generic;

namespace NewsWeb.Core.ApplicationService
{
    public class NewsFacade : INewsFacade
    {
        INewsRepository newsRepository;
        public NewsFacade(INewsRepository newsRepository)
        {
            this.newsRepository = newsRepository;
        }
        public IEnumerable<News> GetHottestNews(int count)
        {
            return newsRepository.GetHottestNews(count);
        }
        public IEnumerable<News> FindByCategory(int categoryId)
        {
            return newsRepository.FindByCategory(categoryId);
        }
        public IEnumerable<News> HomeSearch(string search)
        {
            return newsRepository.HomeSearch(search);
        }
        public IEnumerable<News> GetAll()
        {
            return newsRepository.GetAll();
        }
        public void CreateNews(News news)
        {
            newsRepository.CreateNews(news);
        }
        public void Delete(int id)
        {
            newsRepository.Delete(id);
        }
        public dynamic NewsDetails(int id)
        {
            return newsRepository.NewsDetails(id);
        }
    }
}
