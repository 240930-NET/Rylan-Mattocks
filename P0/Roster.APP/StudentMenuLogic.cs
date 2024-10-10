using System.ComponentModel.Design;
using System.Security.Cryptography.X509Certificates;
using Roster.APP;

public static class StudentMenuLogic{
    private static List<string> Options = [
            "1", "View",
            "2", "Add",
            "3", "Remove",
            "4", "Edit",
            "5", "{0}",
            "6", "Update",
            "7", "Delete",
            "9", "Back",
            "0", "Save",
        ];
    private static readonly string AddClass = "\nType the class you would like to add: ";
    private static readonly string RemoveClass = "\nType the class you would like to remove: ";
    private static readonly string EditClass = "\nType the class you would like to edit: ";
    private static readonly string NewClass = "\nType the new class: ";
    private static readonly string NewInfo = "\nType in your new info: ";
    private static readonly string SignIn = "\nPlease sign in again!";

    public static int GetUserOption(Student student){
        object[] formatStrings = [student.FirstName!];
        Options[9] = String.Format(Options[9], formatStrings);
        string userInput = ReadInput.GetUserInput(Options);
        if (userInput == Options[0] || userInput == Options[1]){
            student.DisplayClasses();
            return 0;
        }
        else if (userInput == Options[2] || userInput == Options[3]) {
            Console.WriteLine(AddClass);
            string subject = ReadInput.GetUserInput();
            Tuple <bool, string> validInput = InputValidation.IsError(subject);
            if (validInput.Item1){
                Console.WriteLine(validInput.Item2);
                return 0;
            }
            student.AddClass(subject);
            return 0;
        }
        else if (userInput == Options[4] || userInput == Options[5]) {
            Console.WriteLine(RemoveClass);
            string subject = ReadInput.GetUserInput();
            Tuple <bool, string> validInput = InputValidation.IsError(subject);
            if (validInput.Item1){
                Console.WriteLine(validInput.Item2);
                return 0;
            }
            student.RemoveClass(subject);
            return 0;
        }
        else if (userInput == Options[6] || userInput == Options[7]) {
            Console.WriteLine(EditClass);
            string userSubject = ReadInput.GetUserInput(student.Classes);
            if (!student.IsClass(userSubject)){
                return 0;
            }
            Console.WriteLine(NewClass);
            string newSubject = ReadInput.GetUserInput();
            Tuple<bool, string> stringError = InputValidation.IsError(newSubject);
            if (stringError.Item1){
                Console.WriteLine(stringError.Item2);
                return 0;
            }
            student.UpdateClass(userSubject, newSubject);
            return 0;
        }
        else if (userInput == Options[8] || userInput == Options[9]) {
            student.DisplayStudent();
            return 0;
        }
        else if (userInput == Options[10] || userInput == Options[11]) {
            Console.WriteLine(NewInfo);
            student.FirstName = PersonLogic.GetPersonFName();
            student.LastName = PersonLogic.GetPersonLName();
            student.Age = PersonLogic.GetPersonAge();
            Console.WriteLine(SignIn);
            return -2;
        } // might have to make -1
        else if (userInput == Options[12] || userInput == Options[13]) {
            bool validInput;
            do{
                validInput = InputValidation.ConfirmInput(userInput);
            } while(!validInput);
            Data.RemovePerson(student);
            Data.SaveData();
            return -2;
            }
        else if (userInput == Options[14] || userInput == Options[15]) {
            return -2;
            }
        else if (userInput == Options[16] || userInput == Options[17]) {
            Data.SaveData();
            return 0;
        }
        return 0;
    }
}