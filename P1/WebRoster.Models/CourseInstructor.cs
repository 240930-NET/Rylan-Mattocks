namespace WebRoster.Models;
public class CourseInstructor
{
    public int ID { get; set; }
    public int CourseID { get; set; }
    public int InstructorID { get; set; }

    public Course Course { get; set; }
    public User Instructor { get; set; }
}