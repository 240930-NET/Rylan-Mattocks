using WebRoster.Data;
using WebRoster.Models;
namespace WebRoster.Services;
public class CourseService : ICourseService{
    private readonly ICourseRepo _courseRepo;
    public CourseService(ICourseRepo courseRepo){
        this._courseRepo = courseRepo;
    }
    public async Task<List<Course>> GetAllCoursesAsync() {
        return await _courseRepo.GetAllCoursesAsync();
    }
    public async Task<Course> GetCourseByIdAsync(int id) {
        return await _courseRepo.GetCourseByIdAsync(id);
    }
    public async Task AddCourseAsync(Course course) {
        await _courseRepo.AddCourseAsync(course);
    }
    public async Task UpdateCourseAsync(Course course) {
        Course existingCourse = await _courseRepo.GetCourseByIdAsync(course.ID);
        if (existingCourse is null) throw new Exception();
        await _courseRepo.UpdateCourseAsync(course);
    }
    public async Task DeleteCourseAsync(int id) {
        Course course = await _courseRepo.GetCourseByIdAsync(id);
        if (course is null) throw new Exception();
        await _courseRepo.DeleteCourseAsync(course);
    }
}