using NewsWeb.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace NewsWeb.Core.Contracts
{
    public interface INewsRepository
    {
        List<News> GetHottestNews(int count);
        List<News> HomeSearch(string search);
        News Get(int id);
        List<News> GetAll();
        void CreateNews(News news);
        void Delete(int id);
        dynamic NewsDetails(int id);
        List<News> FindByCategory(int categoryId);
    }
}
