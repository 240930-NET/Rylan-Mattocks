using Roster.APP;

public static class MainMenuLogic{
    private static readonly List<string> Options = ["1", "Teacher", "2", "Student", "Back"];

    public static int GetUserType(){
        string userInput = ReadInput.GetUserInput(Options);
        if (userInput == Options[0] || userInput == Options[1]) return 1;
        else if (userInput == Options[2] || userInput == Options[3]) return 2;
        else if (userInput == Options[4]) return -2;
        else return 0;
    }

    public static int VerifyUser(string firstName, string lastName, int userID){
        if (userID == 0) return 0;
        if (PersonLogic.CheckPerson(firstName, lastName)){
            if (PersonLogic.CheckPerson(firstName, lastName, userID)){
                if (PersonLogic.CheckStudent(userID) is not null) return 2;
                return 1;
            }
            else return -1;
        }
        else{
            return 0;
        }
    }

    public static Person CreatePerson(string userFName, string userLName, int userType){
        int userAge = PersonLogic.GetPersonAge();
        switch(userType){
            case 1:
                string userSubject = PersonLogic.GetPersonSubject();
                Person teacher = PersonLogic.CreateTeacher(userFName, userLName, userAge, userSubject);
                Data.AddPeople(teacher);
                return teacher;
            case 2:
                Person student = PersonLogic.CreateStudent(userFName, userLName, userAge);
                Data.AddPeople(student);
                return student;
            default:
                Person person = new Teacher();
                return person;
        }
    }

    public static Person GetPerson(int userID, int userType){
        switch(userType){
            case 1:
                Person teacher = (Teacher)Data.People.Where(Person => Person.UserID == userID);
                return teacher;
            case 2:
                Person student = (Student)Data.People.Where(Person => Person.UserID == userID);
                return student;
            default:
                Person person = new Teacher();
                return person;
        }
    }
}