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
        string[] getStrings();
    }
}
