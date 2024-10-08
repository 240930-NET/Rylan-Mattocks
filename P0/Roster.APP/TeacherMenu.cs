using Roster.APP;

public class TeacherMenu{
    private static readonly string TeacherOptions = (
            "\nSelect an Option: \n" +
            "1. \'View\' students                          " + "6. View \'{0}\' info\n" +
            "2. \'Add\' a student                          " + "7. \'Update\' {0} info\n" +
            "3. \'Remove\' a student                       " + "8. \'Delete\' {0}\n" +
            "4. \'Edit\' a student\n" +
            "5. \'Create\' a new student\n\n" +
            "9. \'Back\' a menu                            " + "0. \'Save\' data"
        );

    public static int Menu(Person person){
        Teacher user = (Teacher)person;
        object[] formatStrings = [user.FirstName!];
        string userOptions = String.Format(TeacherOptions, formatStrings);
        Console.WriteLine(userOptions);
        return TeacherMenuLogic.GetUserOption(user);
    }
}