using Moq;
using WebRoster.Data;
using WebRoster.Models;
using WebRoster.Services;
namespace WebRoster.TEST;

public class UserServiceTests
{
    [Theory]
    [InlineData(0)]
    [InlineData(5)]
    public async void GetAllUsersReturnsList(int users)
    {
        Mock<IUserRepo> mockRepo = new();
        UserService userService = new(mockRepo.Object);
        List<User> userList = [];

        for (int i = 0; i < users; i++) {
            userList.Add(new User {});
        }

        mockRepo.Setup(repo => repo.GetAllUsersAsync()).ReturnsAsync(userList);
        var result = await userService.GetAllUsersAsync();

        Assert.Equal(users, result.Count);
    }

    [Theory]
    [InlineData(1)]
    [InlineData(4)]
    public async void GetUserByIdReturnsUser(int id){
        Mock<IUserRepo> mockRepo = new();
        UserService userService = new(mockRepo.Object);
        List<User> userList = [
            new User {ID = 1},
            new User {ID = 2},
            new User {ID = 3},
            new User {ID = 4}
        ];

        mockRepo.Setup(repo => repo.GetUserByIdAsync(It.IsAny<int>())).ReturnsAsync(userList.FirstOrDefault(u => u.ID == id));
        var result = await userService.GetUserByIdAsync(id);

        Assert.Equal(id, result.ID);
    }

    [Theory]
    [InlineData(0)]
    [InlineData(-1)]
    [InlineData(7)]
    public async void GetUserByIdThrowsException(int id) {
        Mock<IUserRepo> mockRepo = new();
        UserService userService = new(mockRepo.Object);
        List<User> userList = [
            new User {ID = 1},
            new User {ID = 2},
            new User {ID = 3},
            new User {ID = 4}
        ];

        mockRepo.Setup(repo => repo.GetUserByIdAsync(It.IsAny<int>())).ReturnsAsync(userList.FirstOrDefault(u => u.ID == id));

        await Assert.ThrowsAnyAsync<NullReferenceException>(() => userService.GetUserByIdAsync(id));
    }

    [Fact]
    public async void AddUserToList() {
        Mock<IUserRepo> mockRepo = new();
        UserService userService = new(mockRepo.Object);
        List<User> userList = [
            new User {ID = 1},
            new User {ID = 2},
            new User {ID = 3},
            new User {ID = 4}
        ];

        User newUser = new() {ID = 5};

        mockRepo.Setup(repo => repo.AddUserAsync(It.IsAny<User>())).Callback(() => userList.Add(newUser));

        await userService.AddUserAsync(newUser);

        Assert.Contains(userList, u => u.ID == newUser.ID);
    }

    [Theory]
    [InlineData(1, "john")]
    [InlineData(3, "jane")]
    public async void UpdateUserToList(int id, string newName) {
        Mock<IUserRepo> mockRepo = new();
        UserService userService = new(mockRepo.Object);
        List<User> userList = [
            new User {ID = 1},
            new User {ID = 2},
            new User {ID = 3},
            new User {ID = 4}
        ];

        User newUser = new() {ID = id, FirstName = newName};

        mockRepo.Setup(repo => repo.UpdateUserAsync(It.IsAny<User>())).Callback(() => userList.FirstOrDefault(u => u.ID == id)!.FirstName = newUser.FirstName);
        mockRepo.Setup(repo => repo.GetUserByIdAsync(It.IsAny<int>())).ReturnsAsync(userList.FirstOrDefault(u => u.ID == id));

        await userService.UpdateUserAsync(newUser);

        Assert.Equal(userList[id - 1].FirstName, newName);
    }

    [Theory]
    [InlineData(1)]
    [InlineData(3)]
    public async void DeleteUserFromList(int id) {
        Mock<IUserRepo> mockRepo = new();
        UserService userService = new(mockRepo.Object);
        List<User> userList = [
            new User {ID = 1},
            new User {ID = 2},
            new User {ID = 3},
            new User {ID = 4}
        ];

        mockRepo.Setup(repo => repo.DeleteUserAsync(It.IsAny<User>())).Callback(() => userList.RemoveAll(u => u.ID == id));
        mockRepo.Setup(repo => repo.GetUserByIdAsync(It.IsAny<int>())).ReturnsAsync(userList.FirstOrDefault(u => u.ID == id));

        await userService.DeleteUserAsync(id);
        
        Assert.DoesNotContain(userList, u => u.ID == id);
    }
}