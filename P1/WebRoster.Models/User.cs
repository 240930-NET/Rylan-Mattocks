using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace WebRoster.Models;
public class User{
    [Key]
    // primary key
    public int ID {get; set;}
    public string FirstName {get; set;}
    public string LastName {get; set;}
    public string Email {get; set;}
    public string UserName {get; set;}
    public string Password {get; set;}
    // foreign keys
    public int RoleID {get; set;}
    public UserDetail UserDetail {get; set;}
    public Role Role {get; set;}
    public List<CourseInstructor> CourseInstructors {get; set;}
    public List<CourseStudent> CourseStudents {get; set;}

    /*public Person(){}
    public Person(string fName, string lName, int age){
        this.FirstName = fName;
        this.LastName = lName;
        this.Age = age;
        this.UserName = fName + lName + this.ID;
        this.Password = "Password" + this.ID;
    }
    public Person(string fName, string lName, int age, string userName, string password, int type){
        this.FirstName = fName;
        this.LastName = lName;
        this.Age = age;
        this.UserName = userName;
        this.Password = password;
        //this.PersonTypeID = type;
    }*/
}