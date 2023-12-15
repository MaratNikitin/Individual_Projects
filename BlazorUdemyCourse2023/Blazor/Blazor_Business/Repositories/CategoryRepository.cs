using AutoMapper;
using Blazor_Business.Repositories.IRepositories;
using Blazor_DataAccess;
using Blazor_DataAccess.Data;
using Blazor_Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blazor_Business.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly AppDBContext _dbContext;
        private readonly IMapper _mapper;

        public CategoryRepository(AppDBContext appDBContext, IMapper mapper)
        {
            _dbContext = appDBContext;
            _mapper = mapper;
        }

        public CategoryDTO Create(CategoryDTO objDTO)
        {
            
            // Manual mapping (replaced by AutoMapper mapping below):
            //Category category = new Category()
            //{
            //    Name = objDTO.Name,
            //    Id = objDTO.Id,
            //    CreatedDate = DateTime.Now
            //};

            // Convert from CategoryDTO to Category using AutoMapper:
            Category category = _mapper.Map<CategoryDTO,Category>(objDTO);

            _dbContext.Categories.Add(category);
            _dbContext.SaveChanges();

            // Manual mapping (replaced by AutoMapper mapping below):
            //return new CategoryDTO()
            //{
            //    Id = category.Id,
            //    Name = category.Name
            //};

            // Convert from Category to CategoryDTO using AutoMapper:
            return _mapper.Map<Category, CategoryDTO>(category);
        }

        public int Delete(int categoryId)
        {
            throw new NotImplementedException();
        }

        public CategoryDTO Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<CategoryDTO> GetAll()
        {
            throw new NotImplementedException();
        }

        public CategoryDTO Update(CategoryDTO objDTO)
        {
            throw new NotImplementedException();
        }
    }
}
