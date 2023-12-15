using Blazor_Models;

namespace Blazor_Business.Repositories.IRepositories
{
    public interface ICategoryRepository
    {
        public CategoryDTO Create(CategoryDTO objDTO);
        public CategoryDTO Update(CategoryDTO objDTO);
        public IEnumerable<CategoryDTO> GetAll();
        public int Delete(int categoryId);
        public CategoryDTO Get(int id);
    }
}
