using NewsWeb.Core.Entities;
using System.Collections.Generic;

namespace NewsWeb.Core.Contracts
{
    public interface ICategoryFacade
    {
        IEnumerable<Category> GetAll();
        public void CreateCategory(Category category);
    }
}
