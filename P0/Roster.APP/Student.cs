namespace Roster.APP;

public class Student : Person{
    public List<string> Classes {get; set;} = [];
    public Student(){}
    public Student(string fName, string lName, int age){
        FirstName = fName;
        LastName = lName;
        this.Age = age;
        this.UserID = NextID;
        NextID++;
    }

    public void AddClass(string subject){
        if (this.Classes.Contains(subject)) Console.WriteLine($"\n{subject} already exists!");
        else this.Classes.Add(subject);
    }

    public void RemoveClass(string subject){
        if (!this.Classes.Remove(subject)) Console.WriteLine($"\n{subject} does not exist!");
    }

    public void DisplayClasses(){
        if (this.Classes.Count != 0)
        {
            Console.WriteLine();
            foreach(string subject in this.Classes){
                Console.WriteLine($"You are enrolled in {subject}!");
            }
        }
        else Console.WriteLine("\nYou are not enrolled in any classes!");
    }

    public bool IsClass(string subject){
        return this.Classes.Contains(subject);
    }

    public void UpdateClass(string oldSubject, string newSubject){
        int index = Classes.FindIndex(subject => subject == oldSubject); 
        this.Classes[index] = newSubject;
    }

    public void DisplayStudent(){
        if (this.Classes.Count != 0) Console.WriteLine($"\n{this.FirstName} {this.LastName} is {this.Age}.\nThey are enrolled in {this.Classes.Count} classes.");
        else Console.WriteLine($"\n{this.FirstName} {this.LastName} is {this.Age}.\nThey are not enrolled in any classes!");
        Console.WriteLine($"Your User ID is {this.UserID}");
    }

}