namespace WebRoster.Models;
public class Course{
    public int ID {get; set;}
    public string CourseName {get; set;}
    public List<CourseInstructor> CourseInstructors {get; set;}
    public List<CourseStudent> CourseStudents {get; set;}
    /*public Subject(){}
    public Subject(string subject){ 
        this.SubjectName = subject;
    }*/
}