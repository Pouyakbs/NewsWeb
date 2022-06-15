using NewsWeb.Core.Entities;
using System;
using System.Collections;
using System.Collections.Generic;

namespace NewsWeb.Core.Contracts
{
    public interface INewsFacade
    {
        IEnumerable<News> GetHottestNews(int count);
        IEnumerable<News> FindByCategory(int categoryId);
        IEnumerable<News> HomeSearch(string search);
        IEnumerable<News> GetAll();
        dynamic NewsDetails(int id);
        void CreateNews(News news);
        void Delete(int id);
    }
}
