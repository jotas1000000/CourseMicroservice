using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CourseAPI.Data.Entity
{
    public class CourseEntity
    {
        [Key]
        public int? Id { get; set; }
        public string Name { get; set; }
        public string Price { get; set; }
        public string StartDate { get; set; }
        public string Teacher { get; set; }
    }
}
