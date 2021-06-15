using AutoMapper;
using CourseAPI.Data.Entity;
using CourseAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CourseAPI.Data
{
    public class APIProfile:Profile
    {
        public APIProfile()
        {
            this.CreateMap<CourseEntity, CourseModel>()
                .ReverseMap();
        }
    }
}
