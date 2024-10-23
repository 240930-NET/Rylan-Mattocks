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
        User? user = await _userRepo.GetUserByIdAsync(id);
        if (user is null) throw new NullReferenceException();
        return user;
    }
    public async Task AddUserAsync(User user) {
        await _userRepo.AddUserAsync(user);
    }
    public async Task UpdateUserAsync(User user) {
        await GetUserByIdAsync(user.ID);
        await _userRepo.UpdateUserAsync(user);
    }
    public async Task DeleteUserAsync(int id) {
        await _userRepo.DeleteUserAsync(await GetUserByIdAsync(id));
    }
}