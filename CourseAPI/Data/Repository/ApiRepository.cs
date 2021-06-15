using CourseAPI.Data.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CourseAPI.Data.Repository
{
    public class ApiRepository : IApiRepository
    {
        private ApiDbContext dbContext;

        public ApiRepository(ApiDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public void AddCourseAsync(CourseEntity course)
        {
            this.dbContext.Courses.Add(course);
        }

        public async Task<IEnumerable<CourseEntity>> GetAllCourses()
        {
            IQueryable<CourseEntity> query = dbContext.Courses;
            // = query.Where(c => c.Status == true);
            query = query.AsNoTracking();
            return await query.ToArrayAsync();
        }

        public string[] getStrings()
        {
            return new string[] { "Hola", "value2" };
        }

        public async Task<bool> SaveChangesAsync()
        {
            try
            {
                return (await this.dbContext.SaveChangesAsync()) > 0;

            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
