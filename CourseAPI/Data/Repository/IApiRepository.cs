using CourseAPI.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CourseAPI.Data.Repository
{
    public interface IApiRepository
    {
        Task<IEnumerable<CourseEntity>> GetAllCourses();
        void AddCourseAsync(CourseEntity course);
        string[] getStrings();
        Task<bool> SaveChangesAsync();


    }
}
