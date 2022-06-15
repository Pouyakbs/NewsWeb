using NewsWeb.Core.Entities;
using System.Collections.Generic;

namespace NewsWeb.Core.Contracts
{
    public interface ICategoryRepository
    {
        List<Category> GetAll();
        Category Get(int id);
        void CreateCategory(Category category);
    }
}
