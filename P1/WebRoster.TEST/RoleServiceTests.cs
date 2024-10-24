using Moq;
using WebRoster.Data;
using WebRoster.Models;
using WebRoster.Services;
namespace WebRoster.TEST;

public class RoleServiceTests
{
    [Theory]
    [InlineData(0)]
    [InlineData(5)]
    public async void GetAllRolesList(int roles)
    {
        Mock<IRoleRepo> mockRepo = new();
        RoleService roleService = new(mockRepo.Object);
        List<Role> roleList = [];

        for (int i = 0; i < roles; i++) {
            roleList.Add(new Role {});
        }

        mockRepo.Setup(repo => repo.GetAllRolesAsync()).ReturnsAsync(roleList);
        var result = await roleService.GetAllRolesAsync();

        Assert.Equal(roles, result.Count);
    }

    [Theory]
    [InlineData(1)]
    [InlineData(4)]
    public async void GetRoleByIdReturnsRole(int id){
        Mock<IRoleRepo> mockRepo = new();
        RoleService roleService = new(mockRepo.Object);
        List<Role> roleList = [
            new Role {ID = 1},
            new Role {ID = 2},
            new Role {ID = 3},
            new Role {ID = 4}
        ];

        mockRepo.Setup(repo => repo.GetRoleByIdAsync(It.IsAny<int>())).ReturnsAsync(roleList.FirstOrDefault(r => r.ID == id));
        var result = await roleService.GetRoleByIdAsync(id);

        Assert.Equal(id, result.ID);
    }

    [Theory]
    [InlineData(0)]
    [InlineData(-1)]
    [InlineData(7)]
    public async void GetRoleByIdThrowsException(int id){
        Mock<IRoleRepo> mockRepo = new();
        RoleService roleService = new(mockRepo.Object);
        List<Role> roleList = [
            new Role {ID = 1},
            new Role {ID = 2},
            new Role {ID = 3},
            new Role {ID = 4}
        ];

        mockRepo.Setup(repo => repo.GetRoleByIdAsync(It.IsAny<int>())).ReturnsAsync(roleList.FirstOrDefault(r => r.ID == id));

        await Assert.ThrowsAnyAsync<NullReferenceException>(() => roleService.GetRoleByIdAsync(id));
    }

    [Fact]
    public async void AddRoleToList(){
        Mock<IRoleRepo> mockRepo = new();
        RoleService roleService = new(mockRepo.Object);
        List<Role> roleList = [
            new Role {ID = 1},
            new Role {ID = 2},
            new Role {ID = 3},
            new Role {ID = 4}
        ];

        Role newRole = new Role() {ID = 5};

        mockRepo.Setup(repo => repo.AddRoleAsync(It.IsAny<Role>())).Callback(() => roleList.Add(newRole));

        await roleService.AddRoleAsync(newRole);

        Assert.Contains(roleList, r => r.ID == newRole.ID);
    }

    [Theory]
    [InlineData(1, "teach")]
    [InlineData(3, "stud")]
    public async void UpdateRoleToList(int id, string newName) {
        Mock<IRoleRepo> mockRepo = new();
        RoleService roleService = new(mockRepo.Object);
        List<Role> roleList = [
            new Role {ID = 1},
            new Role {ID = 2},
            new Role {ID = 3},
            new Role {ID = 4}
        ];

        Role newRole = new() {ID = id, RoleName = newName};

        mockRepo.Setup(repo => repo.UpdateRoleAsync(It.IsAny<Role>())).Callback(() => roleList.FirstOrDefault(r => r.ID == newRole.ID)!.RoleName = newRole.RoleName);
        mockRepo.Setup(repo => repo.GetRoleByIdAsync(It.IsAny<int>())).ReturnsAsync(roleList.FirstOrDefault(r => r.ID == id));

        await roleService.UpdateRoleAsync(newRole);

        Assert.Equal(roleList[id - 1].RoleName, newName);
    }

    [Theory]
    [InlineData(1)]
    [InlineData(3)]
    public async void DeleteRoleFromList(int id){
        Mock<IRoleRepo> mockRepo = new();
        RoleService roleService = new(mockRepo.Object);
        List<Role> roleList = [
            new Role {ID = 1},
            new Role {ID = 2},
            new Role {ID = 3},
            new Role {ID = 4}
        ];

        mockRepo.Setup(repo => repo.DeleteRoleAsync(It.IsAny<Role>())).Callback(() => roleList.RemoveAll(r => r.ID == id));
        mockRepo.Setup(repo => repo.GetRoleByIdAsync(It.IsAny<int>())).ReturnsAsync(roleList.FirstOrDefault(r => r.ID == id));

        await roleService.DeleteRoleAsync(id);

        Assert.DoesNotContain(roleList, r => r.ID == id);
    }
}