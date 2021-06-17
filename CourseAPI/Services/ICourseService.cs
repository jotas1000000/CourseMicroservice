using CourseAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CourseAPI.Services
{
    public interface ICourseService
    {
        Task<IEnumerable<CourseModel>> GetAllCourses();
        Task<CourseModel> AddCourseAsync(CourseModel course);
        Task<CourseModel> UpdateCourseAsync(int id, CourseModel course);
        Task<bool> DeleteCourse(int id);
        Task<CourseModel> GetCourseAsync(int id);

    }
}
