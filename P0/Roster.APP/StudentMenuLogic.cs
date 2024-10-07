using Roster.APP;

public static class StudentMenuLogic{
    private static readonly List<string> options = [
            "1", "view",
            "2", "add",
            "3", "remove",
            "4", "edit",
            "5", $"view {0}",
            "6", "update",
            "7", "delete",
            "9", "back",
            "0", "save",
        ];
    private static readonly string NeedAge = $"\n It looks like you aren't in our system {0} {1}.\nLets get you added!";
    private static readonly string NotInSystem = $"\n I'm sorry {0} {1}, but we couldn't find you in our system!\n Please input your age and we will get you added: ";
    private static readonly string WrongID = $"\n No Problem {0} {1}. Please try logging in again!";

    public static int GetUserOption(string userInput){
        if (userInput == options[0] || userInput == options[1]) return 0;
        else if (userInput == options[2] || userInput == options[3]) return 0;
        else if (userInput == options[4] || userInput == options[5]) return 0;
        else if (userInput == options[6] || userInput == options[7]) return 0;
        else if (userInput == options[8] || userInput == options[9]) return 0;
        else if (userInput == options[10] || userInput == options[11]) return 0; // might have to make -1
        else if (userInput == options[12] || userInput == options[13]) return -1;
        else if (userInput == options[14] || userInput == options[15]) return -1;
        else if (userInput == options[16] || userInput == options[17]) return 0;
        else return 0;
    }

    public static Student VerifyUser(string firstName, string lastName, List<Person> people){
        if (PersonLogic.CheckPerson(firstName, lastName, people)){
            int userID = PersonLogic.GetPersonID();
            Student? userCheck = PersonLogic.CheckStudent(userID, people);
            VerifyStudent();
        }
    }
    
    public static bool VerifyStudent(){
        
    }
}