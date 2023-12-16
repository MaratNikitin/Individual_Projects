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

            category.CreatedDate = DateTime.Now;

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
            var category= _dbContext.Categories.FirstOrDefault(c => c.Id == categoryId);

            if(category != null)
            {
                _dbContext.Remove(category);
                return _dbContext.SaveChanges();
            }

            return 0;            
        }

        public CategoryDTO Get(int categoryId)
        {
            var category = _dbContext.Categories.FirstOrDefault(c => c.Id == categoryId);

            if (category != null)
            {
                return _mapper.Map<Category, CategoryDTO>(category);
            }

            return new CategoryDTO();
        }

        public IEnumerable<CategoryDTO> GetAll()
        {
            //List<Category> categoriesList = _dbContext.Categories.ToList();

            //List<CategoryDTO> categoryDTOsList = new List<CategoryDTO>();

            //foreach (var category in categoriesList)
            //{
            //    var categoryDTO = _mapper.Map<Category, CategoryDTO>(category);
            //    categoryDTOsList.Add(categoryDTO);
            //}

            //return categoryDTOsList;

            return _mapper.Map<IEnumerable<Category>, IEnumerable<CategoryDTO>>(_dbContext.Categories);
        }

        public CategoryDTO Update(CategoryDTO objDTO)
        {
            var category = _dbContext.Categories.FirstOrDefault(c => c.Id == objDTO.Id);

            if (category != null)
            {
                category.Name = objDTO.Name;
                _dbContext.Categories.Update(category);
                _dbContext.SaveChanges();
                return _mapper.Map<Category,CategoryDTO>(category);
            }

            return objDTO;
        }
    }
}
