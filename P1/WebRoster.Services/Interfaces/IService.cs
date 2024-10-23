using WebRoster.Models;

namespace WebRoster.Services;
public interface IUserService{
    public Task<List<User>> GetAllUsersAsync();
    public Task<User> GetUserByIdAsync(int id);
    public Task AddUserAsync(User user);
    public Task UpdateUserAsync(User user);
    public Task DeleteUserAsync(int id);
}

public interface ICourseService{
    public Task<List<Course>> GetAllCoursesAsync();
    public Task<Course> GetCourseByIdAsync(int id);
    public Task AddCourseAsync(Course course);
    public Task UpdateCourseAsync(Course course);
    public Task DeleteCourseAsync(int id);
}

public interface IRoleService {
    public Task<List<Role>> GetAllRolesAsync();
    public Task<Role> GetRoleByIdAsync(int id);
    public Task AddRoleAsync(Role role);
    public Task UpdateRoleAsync(Role role);
    public Task DeleteRoleAsync(int id);
}