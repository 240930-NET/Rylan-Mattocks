using System.Security.Cryptography;
using System.Text.RegularExpressions;
using Roster.APP;

public static class InputValidation{

    public static string CheckString(string? userInput){
        if (String.IsNullOrEmpty(userInput)) return InvalidInputs.IsNull;
        if (!CheckRegex(userInput)) return InvalidInputs.IsInvalid(userInput);
        string cleanInput = Cleaner.Clean(userInput);
        CheckExit(cleanInput);
        return userInput;
    }

    public static string CheckInt(string? userInput){
        if (string.IsNullOrEmpty(userInput)) return InvalidInputs.IsNull;
        if (TryParse(userInput)) return userInput;
        else return InvalidInputs.IsInvalid(userInput);
    }

    private static bool TryParse(string userInput){
        try{
            int userInt = int.Parse(userInput);
            return true;
        }
        catch(Exception){
            return false;
        }
    }

    private static void CheckExit(string userInput){
        if (userInput == "Exit") Environment.Exit(0);
    }

    private static bool CheckRegex(string userInput){
        return Regex.IsMatch(userInput, @"^[a-zA-Z]+$");
    }

    public static Tuple<bool, string> IsError(string userInput){
        if (userInput[0] == '!'){
            return Tuple.Create(true, userInput[1..]);
        }
        return Tuple.Create(false,userInput);
    }

    public static bool CheckAge(int userInt){
        if (userInt <= 100 && userInt >= 1) return true;
        return false;
    }
}