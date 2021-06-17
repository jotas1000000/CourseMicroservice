using CourseAPI.Exceptions;
using CourseAPI.Models;
using CourseAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CourseAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController:ControllerBase
    {
        private ICourseService courseService;
        public CourseController(ICourseService courseService)
        {
            this.courseService = courseService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<string>>> Get()
        {
            try
            {
                return Ok(await courseService.GetAllCourses());
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<CourseModel>> getCourse(int id)
        {
            try
            {
                var course = await courseService.GetCourseAsync(id);
                return Ok(course);
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost]
        public async Task<ActionResult<CourseModel>> Post([FromBody] CourseModel course)
        {
            try
            {
                var newCourse = await courseService.AddCourseAsync(course);
                return Created($"/api/Course/{newCourse.Id}", newCourse);
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<CourseModel>> PutCourse(int id, [FromBody] CourseModel course)
        {
            try
            {
                return Ok(await courseService.UpdateCourseAsync(id, course));
            }
            catch
            {
                throw new Exception("Algo salio mal en el proceso");
            }
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<bool>> DeleteCourse(int id)
        {
            try
            {
                return Ok(await courseService.DeleteCourse(id));
            }
            catch
            {
                throw new Exception("Not possible to show");
            }
         
        }


    }
}
