using NewsWeb.Core.Contracts;
using NewsWeb.Core.Entities;
using System.Collections.Generic;

namespace NewsWeb.Core.ApplicationService
{
    public class CategoryFacade : ICategoryFacade
    {
        ICategoryRepository categoryRepository;
        public CategoryFacade(ICategoryRepository categoryRepository)
        {
            this.categoryRepository = categoryRepository;
        }
        public IEnumerable<Category> GetAll()
        {
            return categoryRepository.GetAll();
        }
        public void CreateCategory(Category category)
        {
            categoryRepository.CreateCategory(category);
        }
    }
}
