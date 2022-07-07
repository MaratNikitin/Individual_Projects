using AutoMapper;
using BusinessClassLibrary.Repository.IRepository;
using DataAccessClassLibrary;
using DataAccessClassLibrary.Data;
using ModelsClassLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessClassLibrary.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ApplicationDbContext _db;
        private readonly IMapper _mapper;

        public CategoryRepository(ApplicationDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        CategoryDTO ICategoryRepository.Create(CategoryDTO objDTO)
        {
            var obj = _mapper.Map<CategoryDTO, Category>(objDTO);
            obj.CreatedDate = DateTime.Now;
            var addedObj = _db.Categories.Add(obj);
            _db.SaveChanges();

            return _mapper.Map<Category, CategoryDTO>(addedObj.Entity);
        }

        int ICategoryRepository.Delete(int id)
        {
            var obj = _db.Categories.FirstOrDefault(u=>u.Id==id);
            if(obj!=null)
            {
                _db.Categories.Remove(obj);
                return _db.SaveChanges();
            }
            else
            {
                return 0;
            }
        }

        CategoryDTO ICategoryRepository.Get(int id)
        {
            var obj = _db.Categories.FirstOrDefault(u => u.Id == id);
            if (obj != null)
            {
                return _mapper.Map<Category, CategoryDTO>(obj);
            }
            else
            {
                return new CategoryDTO();
            }
        }

        IEnumerable<CategoryDTO> ICategoryRepository.GetAll()
        {
            return _mapper.Map<IEnumerable<Category>, IEnumerable<CategoryDTO>>(_db.Categories);
        }

        CategoryDTO ICategoryRepository.Update(CategoryDTO objDTO)
        {
            var objFromDb = _db.Categories.FirstOrDefault(u => u.Id == objDTO.Id);
            if(objFromDb != null)
            {
                objFromDb.Name = objDTO.Name; // Name is the only column that can be updated
                _db.Categories.Update(objFromDb); // changes here happen in Entity Framework Core only
                _db.SaveChanges(); // saving changes in the DB itself
                return _mapper.Map<Category, CategoryDTO>(objFromDb);
            }
            else
            {
                return objDTO;
            }
        }
    }
}
