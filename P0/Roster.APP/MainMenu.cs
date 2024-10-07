using Roster.APP;

public static class MainMenu {

    private static readonly string greeting = "\n\nHello! Welcome to the Class Roster Application!\n" +
                                        "If at any time you would like to exit type \'Exit\' \n";

    public static readonly string userType = (
            "\nSelect one of the following:\n" + 
            "1. I am a \'Teacher\'                         " + "2. I am a \'Student\'"
        );

    // Print greeting string
    public static void PrintGreeting(){
        Console.WriteLine(greeting);
    }

    // Display Start Menu
    public static int StartMenu(){
        Console.WriteLine(userType);
        string userInput = ReadInput.GetUserInput(MainMenuLogic.options);
        return MainMenuLogic.GetUserType(userInput);
    }
}