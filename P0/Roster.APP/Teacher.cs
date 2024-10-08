namespace Roster.APP;

public class Teacher : Person{
    public List<int> StudentID {get; set; } = [];

    public string? Subject {get; set;}
    public Teacher(){}

    public Teacher(string fName, string lName, int age, string subject){
        this.FirstName = fName;
        this.LastName = lName;
        this.Age = age;
        this.Subject = subject;
        this.UserID = this.NextID;
        NextID++;
    }

    public void AddStudents(int studentID){
        if (this.StudentID.Contains(studentID)) Console.WriteLine($"\n{studentID} already exists!");
        else this.StudentID.Add(studentID);
    }

    public void RemoveStudents(int studentID){
        if (!this.StudentID.Remove(studentID)) Console.WriteLine($"\n{studentID} does not exist!");
    }

    public void EditStudents(int oldStudentID, int newStudentID){

    }

    public void DisplayStudents(){
        if (this.StudentID.Count > 0){
            foreach(Person person in Data.People){
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
        Console.WriteLine($"Your User ID is {this.UserID}");
    }
}
