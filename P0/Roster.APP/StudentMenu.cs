using Roster.APP;

public static class StudentMenu{
    private static readonly string StudentOptions = (
            "\nSelect an Option: \n" +
            "1. \'View\' classes                           " + $"5. \'View {0}\' info\n" +
            "2. \'Add\' a class                            " + $"6. \'Update\' {0} info\n" +
            "3. \'Remove\' a class                         " + $"7. \'Delete\' {0}\n" +
            "4. \'Edit\' a class\n\n" +
            "9. \'Back\' a menu                            " +  "0. \'Save\' data"
        );

    public static int Menu(List<Person> people){

        string userFName = PersonLogic.GetPersonFName();
        string userLName = PersonLogic.GetPersonLName();
        Student user = StudentMenuLogic.VerifyUser(userFName, userLName, people);
        
        if (PersonLogic.CheckPerson(userFName, userLName, people)){
            int userID = PersonLogic.GetPersonID();
            user = PersonLogic.CheckStudent(userID, people);
            if (user is null){
                int choice = PersonLogic.VerifyID(userFName, userLName, userID);
                switch(choice){
                    case 1: 
                        Console.WriteLine(String.Format(NotInSystem, "{0} {1}", userFName, userLName));
                        int userInt = int.Parse(ReadInput.GetUserInt());
                        if (InputValidation.CheckAge(userInt)){
                            PersonLogic.CreatePerson(userFName, userLName, userInt, 0);
                            break;
                        }
                        else // need to get new int that is valid
                        break;
                    case 2:
                        Console.WriteLine(String.Format(WrongID, "{0}{1}", userFName, userLName));
                        return 0;
                    case 0: return -1;
                    default: return 0;
                }
                PersonLogic.CreatePerson(userFName, userLName, );
            }
        }
        else{
            PersonLogic.CreatePerson();
        }
        if (PersonLogic.GetPersonType() = 0){

        }
        // check if exists

        // check if any user in list

        // check if user is student
        
        string userOptions = String.Format(StudentOptions, "{0}", user.firstName);
        Console.WriteLine(userOptions);
        string userInput = ReadInput.GetUserInput(MainMenuLogic.options);
        return StudentMenuLogic.GetUserOption(userInput);
    }
}