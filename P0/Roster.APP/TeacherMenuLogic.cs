using Roster.APP;

public class TeacherMenuLogic{
    private static List<string> Options = [
        "1", "View",
        "2", "Add", 
        "3", "Remove",
        "4", "Edit",
        "5", "Create",
        "6", "{0}",  
        "7", "Update", 
        "8", "Delete", 
        "9", "Back", 
        "0", "Save"];

    private static readonly string AddRemoveStudent = "\nPlease enter the Student ID: ";
    private static readonly string OldStudent = "\nPlease enter the Student ID you would like to edit: ";
    private static readonly string NewStudent = "\nPlease enter the new Student ID: ";
    private static readonly string NewInfo = "\nPlease enter your new info: ";
    private static readonly string CreateStudent = "\nPlease enter the new students info: ";

    public static int GetUserOption(Teacher teacher){
        object[] formatString = [teacher.FirstName!];
        Options[11] = string.Format(Options[11], formatString);
        string userInput = ReadInput.GetUserInput(Options);

        if (Options[0] == userInput || Options[1] == userInput){
            teacher.DisplayStudents();
            return 0;
        }
        else if (Options[2] == userInput || Options[3] == userInput){
            Console.WriteLine(AddRemoveStudent);
            teacher.AddStudents(int.Parse(ReadInput.GetUserInt()));
            return 0;
        }
        else if (Options[4] == userInput || Options[5] == userInput){
            Console.WriteLine(AddRemoveStudent);
            teacher.RemoveStudents(int.Parse(ReadInput.GetUserInt()));
            return 0;
        }
        else if (Options[6] == userInput || Options[7] == userInput){
            Console.WriteLine(OldStudent);
            string oldStudentID = ReadInput.GetUserInt(teacher.StudentID);
            Tuple<bool, string> errorString = InputValidation.IsError(oldStudentID);
            if (errorString.Item1){
                Console.WriteLine(errorString.Item2);
                return 0;
            }
            Console.WriteLine(NewStudent);
            string newStudentID = ReadInput.GetUserInt(PersonLogic.GetStudentIDs());
            errorString = InputValidation.IsError(newStudentID);
            if (errorString.Item1){
                Console.WriteLine(errorString.Item2);
                return 0;
            }
            teacher.EditStudents(int.Parse(oldStudentID), int.Parse(newStudentID));
        }
        else if (Options[8] == userInput || Options[9] == userInput){
            Console.WriteLine(CreateStudent);
            Data.AddPeople(PersonLogic.CreateStudent(PersonLogic.GetPersonFName(), PersonLogic.GetPersonLName(), PersonLogic.GetPersonAge()));
            Data.SaveData();
            return 0;
        }
        else if (Options[10] == userInput || Options[11] == userInput){
            teacher.DisplayTeacher();
            return 0;
        }
        else if (Options[12] == userInput || Options[13] == userInput){
            Console.WriteLine(NewInfo);
            teacher.FirstName = PersonLogic.GetPersonFName();
            teacher.LastName = PersonLogic.GetPersonLName();
            teacher.Age = PersonLogic.GetPersonAge();
            teacher.Subject = PersonLogic.GetPersonSubject();
            return 0;
        }
        else if (Options[14] == userInput || Options[15] == userInput){
            InputValidation.ConfirmInput(userInput);
            Data.RemovePerson(teacher);
            Data.SaveData();
            return -1;
        }
        else if (Options[16] == userInput || Options[17] == userInput){
            return -1;
        }
        else if (Options[18] == userInput || Options[19] == userInput){
            Data.SaveData();
            return 0;
        }
        return 0;
    }
}