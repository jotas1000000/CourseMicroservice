using AutoMapper;
using CourseAPI.Data.Entity;
using CourseAPI.Data.Repository;
using CourseAPI.Exceptions;
using CourseAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CourseAPI.Services
{
    public class CourseService : ICourseService
    {
        private IApiRepository repository;
        private readonly IMapper mapper;

        public CourseService(IApiRepository repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        public async Task<CourseModel> AddCourseAsync(CourseModel course)
        {
            var courseEntity = this.mapper.Map<CourseEntity>(course);
            this.repository.AddCourseAsync(courseEntity);
            if (await this.repository.SaveChangesAsync())
            {
                return this.mapper.Map<CourseModel>(courseEntity);
            }
            throw new Exception("There were an error with the DB");

        }

        public async Task<IEnumerable<CourseModel>> GetAllCourses()
        {
            var responseDB = await this.repository.GetAllCourses();
            var listCourses = this.mapper.Map<IEnumerable<CourseModel>>(responseDB);
            return listCourses;
        }

 

        public async Task<CourseModel> UpdateCourseAsync(int id, CourseModel course)
        {
            await this.repository.ValidateCourse(id);
            var courseEntity = mapper.Map<CourseEntity>(course);
            await this.repository.UpdateCourse(courseEntity);
            if (await this.repository.SaveChangesAsync())
                return mapper.Map<CourseModel>(courseEntity);

            throw new Exception("There were an error with the DB");

        }

        public async Task<bool> DeleteCourse(int id)
        {
            await this.repository.ValidateCourse(id);
            await this.repository.DeleteCourses(id);
            if (await this.repository.SaveChangesAsync())
            {
                return true;
            }
            return false;
        }

        public async Task<CourseModel> GetCourseAsync(int id)
        {
            var courseEntity = await this.repository.GetCourse(id);
            if (courseEntity == null)
            {
                throw new Exception("Not Found");
            }
            return this.mapper.Map<CourseModel>(courseEntity);
        }
    }
}
