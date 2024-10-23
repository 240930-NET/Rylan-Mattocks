namespace WebRoster.Models;
public class CourseStudent
{
    public int ID { get; set; }
    public int CourseID { get; set; }
    public int StudentID { get; set; }

    public Course Course { get; set; }
    public User Student { get; set; }
}