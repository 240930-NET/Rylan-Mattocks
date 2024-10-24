namespace WebRoster.Models.DTO;

public class CourseDTO {
    public required string CourseName {get; set;}
    public required List<CourseInstructorDTO> CourseInstructors {get; set;}
}