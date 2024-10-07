using System.Text.RegularExpressions;

namespace Roster.APP;
public static class Cleaner {

    public static string Clean(string str){
        string cleanString = str.Trim().ToLower();
        return Upper(cleanString);
    }

    public static string Upper(string str){
        string upperString = $"{char.ToUpper(str[0])}{str[1..]}";
        return upperString;
    }
}