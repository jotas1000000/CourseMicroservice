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
        Task UpdateCourse(CourseEntity course);
        Task DeleteCourses(int id);
        Task<CourseEntity> GetCourse(int id);

        Task<bool> SaveChangesAsync();
        Task ValidateCourse(int id);


    }
}
