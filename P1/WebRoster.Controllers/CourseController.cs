using WebRoster.Models;
using WebRoster.Services;
using Microsoft.AspNetCore.Mvc;
namespace WebRoster.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CourseController : Controller{
    private readonly ICourseService _courseService;

    public CourseController(ICourseService courseService){
        this._courseService = courseService;
    }
    [HttpGet]
    public async Task<IActionResult> GetCourses(){
        try {
            return Ok(await _courseService.GetAllCoursesAsync());
        }
        catch{
            return BadRequest();
        }
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetCourseById(int id){
        try{
            Course course = await _courseService.GetCourseByIdAsync(id);
            if (course is null) {
                return NotFound();
            }
            return Ok(course);
        }
        catch{
            return BadRequest();
        }
    }

    [HttpPost]
    public async Task<IActionResult> AddCourse([FromBody] Course course){
        try {
            await _courseService.AddCourseAsync(course);
            return CreatedAtAction(nameof(GetCourseById), new {id = course.ID}, course);
        }
        catch {
            return BadRequest();
        }
    }

    [HttpPut]
    public async Task<IActionResult> UpdateCourse([FromBody] Course course){
        try {
            await _courseService.UpdateCourseAsync(course);
            return NoContent();
        }
        catch {
            return BadRequest();
        }
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult>  DeleteCourse(int id){
        try{
            await _courseService.DeleteCourseAsync(id);
            return NoContent();
        }
        catch{
            return BadRequest();
        }
    }
}
