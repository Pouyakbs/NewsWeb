using Microsoft.EntityFrameworkCore;
using NewsWeb.Core.Entities;
using NewsWeb.Infraustraucture.EF;
using System.Collections.Generic;
using System.Linq;

namespace NewsWeb.Infrustructure.Data
{
    public class CategoryRepository
    {
        private readonly MyContext Context;
        public CategoryRepository()
        {
            Context = new MyContext();
        }
        public List<Category> GetAll()
        {
            return Context.Categories.Include(a=> a.News).ToList();
        }
        public Category Get(int id)
        {
            return Context.Categories.Include(a => a.News).First(a => a.CategoryId == id);
        }
        public void CreateCategory(Category category)
        {
            Context.Categories.Add(category);
            Context.SaveChanges();
        }
    }
}
