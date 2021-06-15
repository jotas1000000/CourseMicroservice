using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CourseAPI.Models
{
    public class CourseModel
    {
        public int? Id { get; set; }
        public string Name { get; set; }
        public string Price { get; set; }
        public string StartDate { get; set; }
        public string Teacher { get; set; }
    }
}
