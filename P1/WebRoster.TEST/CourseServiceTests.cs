using Moq;
using WebRoster.Data;
using WebRoster.Models;
using WebRoster.Services;
namespace WebRoster.TEST;

public class CourseServiceTests
{
    [Theory]
    [InlineData(0)]
    [InlineData(5)]
    public async void GetAllCoursesReturnsList(int courses)
    {
        Mock<ICourseRepo> mockRepo = new();
        CourseService courseService = new(mockRepo.Object);
        List<Course> courseList = [];

        for (int i = 0; i < courses; i++) {
            courseList.Add(new Course {});
        }

        mockRepo.Setup(repo => repo.GetAllCoursesAsync()).ReturnsAsync(courseList);

        var result = await courseService.GetAllCoursesAsync();

        Assert.Equal(courses, result.Count);

    }

    [Theory]
    [InlineData(1)]
    [InlineData(4)]
    public async void GetCourseByIdReturnsCourse(int id){
        Mock<ICourseRepo> mockRepo = new();
        CourseService courseService = new(mockRepo.Object);
        List<Course> courseList = [
            new Course {ID = 1},
            new Course {ID = 2},
            new Course {ID = 3},
            new Course {ID = 4}
        ];

        mockRepo.Setup(repo => repo.GetCourseByIdAsync(It.IsAny<int>())).ReturnsAsync(courseList.FirstOrDefault(c => c.ID == id));
        var result = await courseService.GetCourseByIdAsync(id);

        Assert.Equal(id, result.ID);
    }

    [Theory]
    [InlineData(0)]
    [InlineData(-1)]
    [InlineData(7)]
    public async void GetCourseByIdThrowsException(int id){
        Mock<ICourseRepo> mockRepo = new();
        CourseService courseService = new(mockRepo.Object);
        List<Course> courseList = [
            new Course {ID = 1},
            new Course {ID = 2},
            new Course {ID = 3},
            new Course {ID = 4}
        ];

        mockRepo.Setup(repo => repo.GetCourseByIdAsync(It.IsAny<int>())).ReturnsAsync(courseList.FirstOrDefault(c => c.ID == id));

        await Assert.ThrowsAnyAsync<NullReferenceException>(() => courseService.GetCourseByIdAsync(id));
    }

    [Fact]
    public async void AddCourseToList(){
        Mock<ICourseRepo> mockRepo = new();
        CourseService courseService = new(mockRepo.Object);
        List<Course> courseList = [
            new Course {ID = 1},
            new Course {ID = 2},
            new Course {ID = 3},
            new Course {ID = 4}
        ];

        Course newCourse = new() {ID = 5};

        mockRepo.Setup(repo => repo.AddCourseAsync(It.IsAny<Course>())).Callback(() => courseList.Add(newCourse));

        await courseService.AddCourseAsync(newCourse);

        Assert.Contains(courseList, c => c.ID == newCourse.ID);
    }

    [Theory]
    [InlineData(1, "math")]
    [InlineData(3, "english")]
    public async void UpdateCourseToList(int id, string newName){
        Mock<ICourseRepo> mockRepo = new();
        CourseService courseService = new(mockRepo.Object);
        List<Course> courseList = [
            new Course {ID = 1},
            new Course {ID = 2},
            new Course {ID = 3},
            new Course {ID = 4}
        ];

        Course newCourse = new() {ID = id, CourseName = newName};

        mockRepo.Setup(repo => repo.UpdateCourseAsync(It.IsAny<Course>())).Callback(() => courseList.FirstOrDefault(c => c.ID == newCourse.ID)!.CourseName = newCourse.CourseName);
        mockRepo.Setup(repo => repo.GetCourseByIdAsync(It.IsAny<int>())).ReturnsAsync(courseList.FirstOrDefault(c => c.ID == id));

        await courseService.UpdateCourseAsync(newCourse);

        Assert.Equal(courseList[id - 1].CourseName, newName);
    }

    [Theory]
    [InlineData(1)]
    [InlineData(3)]
    public async void DeleteCourseFromList(int id){
        Mock<ICourseRepo> mockRepo = new();
        CourseService courseService = new(mockRepo.Object);
        List<Course> courseList = [
            new Course {ID = 1},
            new Course {ID = 2},
            new Course {ID = 3},
            new Course {ID = 4}
        ];

        mockRepo.Setup(repo => repo.DeleteCourseAsync(It.IsAny<Course>())).Callback(() => courseList.RemoveAll(c => c.ID == id));
        mockRepo.Setup(repo => repo.GetCourseByIdAsync(It.IsAny<int>())).ReturnsAsync(courseList.FirstOrDefault(c => c.ID == id));

        await courseService.DeleteCourseAsync(id);

        Assert.DoesNotContain(courseList, c => c.ID == id);
    }
}