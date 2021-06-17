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

        public async Task DeleteCourses(int id)
        {
            var course = await this.dbContext.Courses.SingleAsync(c => c.Id == id);
            this.dbContext.Courses.Remove(course);
        }

        public async Task<IEnumerable<CourseEntity>> GetAllCourses()
        {
            IQueryable<CourseEntity> query = dbContext.Courses;
            query = query.AsNoTracking();
            return await query.ToArrayAsync();
        }

        public async Task<CourseEntity> GetCourse(int id)
        {
            var query = await this.dbContext.Courses.SingleOrDefaultAsync(c => c.Id == id);
            return query;
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

        public async Task UpdateCourse(CourseEntity course)
        {
            var courseUpdate = await this.dbContext.Courses.SingleAsync(c => c.Id == course.Id);
            courseUpdate.Name = course.Name;
            courseUpdate.Price = course.Price;
            courseUpdate.StartDate = course.StartDate;
            courseUpdate.Teacher = course.Teacher;
        }

        public Task ValidateCourse(int id)
        {
            try
            {
                return GetCourse(id);

            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
