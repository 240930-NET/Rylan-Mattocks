public static class MainMenuLogic{
    public static readonly List<string> options = ["1", "Teacher", "2", "Student", "Back"];
    public static int GetUserType(string userInput){
        if (userInput == options[0] || userInput == options[1]) return 1;
        else if (userInput == options[2] || userInput == options[3]) return 2;
        else if (userInput == options[4]) return -1;
        else return 0;
    }
}