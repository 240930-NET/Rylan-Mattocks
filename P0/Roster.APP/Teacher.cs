namespace Roster.APP;

public class Teacher : Person{
    public List<int> StudentID {get; set; } = [];

    public string? Subject {get; set;}
    public Teacher(){}

    public Teacher(string fName, string lName, int age, string subject){
        FirstName = fName;
        LastName = lName;
        this.Age = age;
        this.Subject = subject;
        this.UserID = this.NextID;
        this.NextID++;
    }

    public void DisplayStudents(List<Person> people){
        if (this.StudentID.Count > 0){
            foreach(Person person in people){
                if (person is Student stud){
                    if (this.StudentID.Contains(stud.UserID)){
                        stud.DisplayStudent();
                    }
                }
            }
        }
        else Console.WriteLine("\nYou do not have any students");
    }

    public void DisplayTeacher(){
        if (this.StudentID.Count != 0) Console.WriteLine($"\n{this.FirstName} {this.LastName} is {this.Age}.\nThey teach {this.Subject}.\nThey have {this.StudentID.Count} students!");
        else Console.WriteLine($"\n{this.FirstName} {this.LastName} is {this.Age}.\nThey teach {this.Subject}.\nThey do not have any students!");
    }
}
