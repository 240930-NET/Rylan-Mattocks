using System.Runtime.CompilerServices;
using Roster.APP;

public static class PersonLogic{

    private static readonly string FirstName = "\nPlease enter first name: ";
    private static readonly string LastName = "\nPlease enter last name: ";
    private static readonly string PersonID = "\nIf you are a new user or forgot your User ID: enter 0.\nPlease enter User ID: ";
    private static readonly string NoUserIDFound = "\nI am sorry {0} {1}, but we do not have anyone in our system with the User ID: {2}.\nIs this User ID: {2} correct?\n" +
                                                    "1. \'Yes\'               2. \'No\'";
    private static readonly string PersonAge = "\nPlease enter age(1-100): ";
    private static readonly string PersonSubject = "\nPlease enter subject: ";
    private static List<string> Options = ["1, Yes, 2, No", "Back"];
    private static string ShowUserID = "\nYou have been added to our system {0}!\nYour User ID is {1}. You will need this to access your account.";

    public static Type GetPersonType(Person person){
        if (person is Student student) return student.GetType();
        else if (person is Teacher teacher) return teacher.GetType();
        else return person.GetType();
    }

    public static Tuple<string,string,int> GetPersonInfo(){
        Tuple<string,string> fullName = GetPersonName();
        return Tuple.Create(fullName.Item1, fullName.Item2, GetPersonID());
    }

    public static Tuple<string,string> GetPersonName(){
        return Tuple.Create(GetPersonFName(), GetPersonLName());
    }

    public static string GetPersonFName(){
        Console.WriteLine(FirstName);
        string? userInput = ReadInput.GetUserInput();
        Tuple<bool,string> checkInput = InputValidation.IsError(userInput);
        if (checkInput.Item1){
            Console.WriteLine(checkInput.Item2);
            return GetPersonFName();
        }
        return userInput;
    }

    public static string GetPersonLName(){
        Console.WriteLine(LastName);
        string? userInput = ReadInput.GetUserInput();
        Tuple<bool,string> checkInput = InputValidation.IsError(userInput);
        if (checkInput.Item1){
            Console.WriteLine(checkInput.Item2);
            return GetPersonLName();
        }
        return userInput;
    }

    public static int GetPersonID(){
        Console.WriteLine(PersonID);
        string? userInput = ReadInput.GetUserInt();
        Tuple<bool,string> checkInput = InputValidation.IsError(userInput);
        if (checkInput.Item1){
            Console.WriteLine(checkInput.Item2);
            return GetPersonID();
        }
        else return int.Parse(userInput);
    }

    public static int GetPersonAge(){
        Console.WriteLine(PersonAge);
        string? userInput = ReadInput.GetUserInt();
        Tuple<bool, string> validInput = InputValidation.IsError(userInput);
        if (validInput.Item1){
            Console.WriteLine(validInput.Item2);
            return GetPersonAge();
        }
        int userInt = int.Parse(userInput);
        userInput = InputValidation.CheckAge(userInt);
        validInput = InputValidation.IsError(userInput);
        if (validInput.Item1){
            Console.WriteLine(validInput.Item2);
            return GetPersonAge();
        }
        return userInt;
    }

    public static string GetPersonSubject(){
        Console.WriteLine(PersonSubject);
        string? userInput = ReadInput.GetUserInput();
        if (!InputValidation.ConfirmInput(userInput)) return GetPersonSubject();
        return userInput;
    }

    public static bool CheckPerson(string firstName, string lastName){
        foreach (Person person in Data.People){
            if (person.FirstName == firstName && person.LastName == lastName) return true;
        }
        return false;
    }

    public static bool CheckPerson(string firstName, string lastName, int userID){
        foreach (Person person in Data.People){
            if (person.FirstName == firstName && person.LastName == lastName && person.UserID == userID) return true;
        }
        return false;
    }

    public static Student? CheckStudent(int userID){
        foreach (Person person in Data.People){
            if (person is Student student){
                if (student.UserID == userID) return student;
            }
        }
        return null;
    }
    
    public static Teacher? CheckTeacher(int userID){
        foreach (Person person in Data.People){
            if (person is Teacher teacher){
                if (teacher.UserID == userID) return teacher;
            }
        }
        return null;
    }

    public static Teacher CreateTeacher(string firstName, string lastName, int age, string subject){
        Teacher teacher = new(firstName, lastName, age, subject);
        object[] formatStrings = [teacher.FirstName!, teacher.UserID];
        Console.WriteLine(String.Format(ShowUserID, formatStrings));
        return teacher;
    }

    public static Student CreateStudent(string firstName, string lastName, int age){
        Student student = new(firstName, lastName, age);
        object[] formatStrings = [student.FirstName!, student.UserID];
        Console.WriteLine(String.Format(ShowUserID, formatStrings));
        return student;
    }

    public static int VerifyID(string firstName, string lastName, int userID){
        object[] formatStrings = [firstName, lastName, userID];
        string message = String.Format(NoUserIDFound, formatStrings);
        Console.WriteLine(message);
        string userInput = ReadInput.GetUserInput(Options);
        if (userInput == Options[0] || userInput == Options[1]) return 0;
        else if (userInput == Options[1] || userInput == Options[2]) return 1;
        else return -1;
    }
    
    public static List<int> GetStudentIDs(){
        List<int> studentIDs = [];
        foreach (Person person in Data.People){
            if (person is Student student){
                studentIDs.Add(student.UserID);
            }
        }
        return studentIDs;
    }
}