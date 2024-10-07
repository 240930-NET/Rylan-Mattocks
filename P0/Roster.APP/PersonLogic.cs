using System.Runtime.CompilerServices;
using Roster.APP;

public static class PersonLogic{

    private static readonly string firstName = "\nPlease enter first name: ";
    private static readonly string lastName = "\nPlease enter last name: ";
    private static readonly string personID = "\nPease enter UserID: ";
    private static readonly string NoUserIDFound = $"\nI am sorry {0} {1}, but we do not have anyone in our system with the User ID: {2}.\nIs this User ID: {2} correct?\n" +
                                                    $"1. \'Yes\'               2. \'No\'";

    public static List<string> options = ["1, Yes, 2, No", "Back"];

    public static Type GetPersonType(Person person){
        if (person is Student student) return student.GetType();
        else if (person is Teacher teacher) return teacher.GetType();
        else return person.GetType();
    }

    public static Tuple<string,string,int> GetPersonInfo(){
        return Tuple.Create(GetPersonName().Item1, GetPersonName().Item2, GetPersonID());
    }

    public static Tuple<string,string> GetPersonName(){
        return Tuple.Create(GetPersonFName(), GetPersonLName());
    }

    public static string GetPersonFName(){
        Console.WriteLine(firstName);
        string? userInput = ReadInput.GetUserInput();
        Tuple<bool,string> checkInput = InputValidation.IsError(userInput);
        if (checkInput.Item1){
            Console.WriteLine(checkInput.Item2);
            return GetPersonFName();
        }
        return GetPersonFName();
    }

    public static string GetPersonLName(){
        Console.WriteLine(lastName);
        string? userInput = ReadInput.GetUserInput();
        Tuple<bool,string> checkInput = InputValidation.IsError(userInput);
        if (checkInput.Item1){
            Console.WriteLine(checkInput.Item2);
            return GetPersonFName();
        }
        return GetPersonLName();
    }

    public static int GetPersonID(){
        Console.WriteLine(personID);
        string? userInput = ReadInput.GetUserInt();
        Tuple<bool,string> checkInput = InputValidation.IsError(userInput);
        if (checkInput.Item1){
            Console.WriteLine(checkInput.Item2);
            return GetPersonID();
        }
        else return int.Parse(userInput);
    }

    public static bool CheckPerson(string firstName, string lastName, List<Person> people){
        foreach (Person person in people){
            if (person.FirstName == firstName && person.LastName == lastName) return true;
        }
        return false;
    }

    public static bool CheckPerson(int userID, List<Person> people){
        foreach (Person person in people){
            if (person.UserID == userID) return true;
        }
        return false;
    }

    public static Student? CheckStudent(int userID, List<Person> people){
        foreach (Person person in people){
            if (person is Student student){
                if (student.UserID == userID) return student;
            }
        }
        return null;
    }
    
    public static Teacher? CheckTeacher(int userID, List<Person> people){
        foreach (Person person in people){
            if (person is Teacher teacher){
                if (teacher.UserID == userID) return teacher;
            }
        }
        return null;
    }

    public static void CreatePerson(string firstName, string lastName, int age, int type){
        if (type == 0){
            //create teacher
        }
        else {
            //create student
        }
    }

    public static int VerifyID(string firstName, string lastName, int userID){
        string message = String.Format(NoUserIDFound, "{0} {1} {2}", firstName, lastName, userID);
        Console.WriteLine(message);
        string userInput = ReadInput.GetUserInput(options);
        if (userInput == options[0] || userInput == options[1]) return 0;
        else if (userInput == options[1] || userInput == options[2]) return 1;
        else return -1;
    }
}