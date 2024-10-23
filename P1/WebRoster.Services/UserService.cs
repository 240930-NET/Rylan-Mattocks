using WebRoster.Data;
using WebRoster.Models;
namespace WebRoster.Services;
public class UserService : IUserService {
    private readonly IUserRepo _userRepo;
    public UserService(IUserRepo userRepo) {
        this._userRepo = userRepo;
    }
    public async Task<List<User>> GetAllUsersAsync() {
        return await _userRepo.GetAllUsersAsync();
    }
    public async Task<User> GetUserByIdAsync(int id) {
        return await _userRepo.GetUserByIdAsync(id);
    }
    public async Task AddUserAsync(User user) {
        await _userRepo.AddUserAsync(user);
    }
    public async Task UpdateUserAsync(User user) {
        User existingUser = await _userRepo.GetUserByIdAsync(user.ID);
        if (existingUser is null) throw new Exception();
        await _userRepo.UpdateUserAsync(user);
    }
    public async Task DeleteUserAsync(int id) {
        User user = await _userRepo.GetUserByIdAsync(id);
        if (user is null) throw new Exception();
        await _userRepo.DeleteUserAsync(user);
    }
}