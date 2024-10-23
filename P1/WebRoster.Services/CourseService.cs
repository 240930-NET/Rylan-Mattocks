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
        Course? course = await _courseRepo.GetCourseByIdAsync(id);
        if (course is null) throw new NullReferenceException();
        return course;
    }
    public async Task AddCourseAsync(Course course) {
        await _courseRepo.AddCourseAsync(course);
    }
    public async Task UpdateCourseAsync(Course course) {
        await _courseRepo.UpdateCourseAsync(await GetCourseByIdAsync(course.ID));
    }
    public async Task DeleteCourseAsync(int id) {
        await _courseRepo.DeleteCourseAsync(await GetCourseByIdAsync(id));
    }
}