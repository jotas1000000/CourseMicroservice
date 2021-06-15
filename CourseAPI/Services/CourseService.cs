using AutoMapper;
using CourseAPI.Data.Entity;
using CourseAPI.Data.Repository;
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

        public string[] getStrings()
        {
            return this.repository.getStrings();
        }
    }
}
