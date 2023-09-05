using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqDemo.Models
{
    public class UniversityManager: IEnumerable<UniversityManager>, IEnumerable<Student>, IEnumerable<University>
    {
        public List<University> universities;
        public List<Student> students;

        // constructor
        public UniversityManager() 
        {
            universities = new();
            students = new();

            universities.Add(new University { Id = 1, Name = "Yale" });
            universities.Add(new University { Id = 2, Name = "Princeton" });

            students.Add(new Student { Id = 1, Name = "Carla", Gender = "Female", Age = 17, UniversityId = 1 });
            students.Add(new Student { Id = 2, Name = "Tony", Gender = "Male", Age = 21, UniversityId = 1 });
            students.Add(new Student { Id = 3, Name = "Leyla", Gender = "Female", Age = 19, UniversityId = 2 });
            students.Add(new Student { Id = 4, Name = "James", Gender = "Trans-gender", Age = 25, UniversityId = 2 });
            students.Add(new Student { Id = 5, Name = "Linda", Gender = "Female", Age = 22, UniversityId = 2 });
            students.Add(new Student { Id = 6, Name = "Frank", Gender = "Male", Age = 22, UniversityId = 2 });
        }

        public IEnumerator<UniversityManager> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }

        IEnumerator<Student> IEnumerable<Student>.GetEnumerator()
        {
            throw new NotImplementedException();
        }

        IEnumerator<University> IEnumerable<University>.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
