using WebRoster.Data;
using WebRoster.Models;
namespace WebRoster.Services;
public class RoleService : IRoleService{
    private readonly IRoleRepo _roleRepo;
    public RoleService(IRoleRepo roleRepo){
        this._roleRepo = roleRepo;
    }
    public async Task<List<Role>> GetAllRolesAsync() {
        return await _roleRepo.GetAllRolesAsync();
    }
    public async Task<Role> GetRoleByIdAsync(int id) {
        Role? role = await _roleRepo.GetRoleByIdAsync(id);
        if (role is null) throw new NullReferenceException();
        return role;
    }
    public async Task AddRoleAsync(Role role) {
        await _roleRepo.AddRoleAsync(role);
    }
    public async Task UpdateRoleAsync(Role role) {
        await GetRoleByIdAsync(role.ID);
        await _roleRepo.UpdateRoleAsync(role);
    }
    public async Task DeleteRoleAsync(int id) {
        await _roleRepo.DeleteRoleAsync(await GetRoleByIdAsync(id));
    }
}