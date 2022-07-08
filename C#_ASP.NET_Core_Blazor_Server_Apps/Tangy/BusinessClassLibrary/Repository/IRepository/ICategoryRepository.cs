/*
 * This app is built based on Udemy's Blazor Learning course, part of the self-study.
 *      It allows a full range of CRUD operations with a SQL Server DB and demonstrates Javascript integrations
 *      into the Blazor Server projects.
 * Author: Marat Nikitin.
 * When: July 2022.
 * This interface is a basis for implementing CRUD methods for the DB.
 */

using ModelsClassLibrary;

namespace BusinessClassLibrary.Repository.IRepository
{
    public interface ICategoryRepository
    {
        public CategoryDTO Create(CategoryDTO objDTO);
        public CategoryDTO Update(CategoryDTO objDTO);
        public int Delete(int id);
        public CategoryDTO Get(int id);
        public IEnumerable<CategoryDTO> GetAll();
    }
}
 