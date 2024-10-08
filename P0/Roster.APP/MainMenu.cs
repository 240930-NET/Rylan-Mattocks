using Roster.APP;

public static class MainMenu {

    private static readonly string greeting = "\n\nHello! Welcome to the Class Roster Application!\n" +
                                        "If at any time you would like to exit type \'Exit\' \n";

    private static readonly string userType = (
            "\nSelect one of the following:\n" + 
            "1. I am a \'Teacher\'                         " + "2. I am a \'Student\'"
        );

    private static readonly string NoUser = "\nIt looks like you aren't in our system yet.\nLet's get you added!";
    private static readonly string Success = "\nLogin Successful!\nWelcome {0} {1}!";
    private static readonly string IsTeacher = "\nIt looks like you are a teacher!\nWe will redirect you!";
    private static readonly string IsStudent = "\nIt looks like you are a student!\nWe will redirect you!";
    private static readonly string WrongID = "\nI'm sorry {0}, but {0} {1} does not match {2}.\nPlease login again.";
    private static int userChoice;

    // Print greeting string
    public static void PrintGreeting(){
        Console.WriteLine(greeting);
    }

    // Display Start Menu
    public static void StartMenu(){
        Console.WriteLine(userType);
        userChoice = MainMenuLogic.GetUserType();
        if (userChoice == -2) StartMenu();
    }

    public static Tuple<int, Person> GetUserType(){
        StartMenu();
        Tuple<string, string, int> userInfo = PersonLogic.GetPersonInfo();
        string userFName = userInfo.Item1;
        string userLName = userInfo.Item2;
        int userID = userInfo.Item3;

        int verifiedUser = MainMenuLogic.VerifyUser(userFName, userLName, userID);
        object[] formatStrings = [userFName, userLName, userID];
        if (verifiedUser == -1){
            //formatStrings = [userFName, userLName, userID];
            Console.WriteLine(String.Format(WrongID,formatStrings));
            Person student = new Student();
            return Tuple.Create(-1, student);
        }
        else if (verifiedUser == userChoice){
            //formatStrings = [userFName, userLName];
            Console.WriteLine(String.Format(Success, formatStrings));
            return Tuple.Create(userChoice, (Person)Data.People.Where(Person => Person.UserID == userID));
        }
        else /*(verifiedUser == 0)*/{
            Console.WriteLine(NoUser);
            return Tuple.Create(userChoice, MainMenuLogic.CreatePerson(userFName, userLName, userChoice));
        }
    }
}