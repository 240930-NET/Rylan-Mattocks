namespace Roster.APP;

using System.ComponentModel.DataAnnotations;
using System.Text.Json;

public class Data{

    public static List<Person> People {get; set; } = [];

    public static async Task SaveStudentsToJson(List<Student> students){

        string studentList = JsonSerializer.Serialize(students);

        try{
            using(StreamWriter sw = File.CreateText("students.txt")){
                await sw.WriteAsync(studentList);
            }
        }
        catch(Exception){
            Console.WriteLine("\nCould not save data.\n");
        }
    }

    public static async Task SaveTeachersToJson(List<Teacher> teachers){

        string teacherList = JsonSerializer.Serialize(teachers);

        try{
            using(StreamWriter sw = File.CreateText("files/teachers.txt")){
                await sw.WriteAsync(teacherList);
            }
        }
        catch(Exception){
            Console.WriteLine("\nCould not save data.\n");
        }
    }

    public static List<Student> GetStudentsFromJson(){
        try {
            using(StreamReader sr = File.OpenText("files/students.txt")){
                string jstring = sr.ReadToEnd();
                if (jstring.Length > 0) return JsonSerializer.Deserialize<List<Student>>(jstring)!;
                else return [];
            }
        }
        catch (Exception){
            Console.WriteLine("\nCould not load data.\n");
            return [];
        }
    }

    public static List<Teacher> GetTeachersFromJson(){
        try {
            using(StreamReader sr = File.OpenText("files/teachers.txt")){
                string jstring = sr.ReadToEnd();
                if (jstring.Length > 0) return JsonSerializer.Deserialize<List<Teacher>>(jstring)!;
                else return [];
            }
        }
        catch (Exception){
            Console.WriteLine("\nCould not load data.\n");
            return [];
        }
    }
    public static void SetPeople(){
        foreach (Student s in GetStudentsFromJson()){
            Data.People.Add(s);
        }
        foreach (Teacher t in GetTeachersFromJson()){
            Data.People.Add(t);
        }
    }

    public static void AddPeople(Person person){
        Data.People.Add(person);
    }

    public static void RemovePerson(Person person){
        Data.People.Remove(person);
    }

    public static void SaveData(){
        List<Student> saveStudents = [];
        List<Teacher> saveTeachers = [];
        foreach (Person person in Data.People){
            if (person is Student student)
                saveStudents.Add(student);
            if (person is Teacher teacher){
                saveTeachers.Add(teacher);
            }
        }
        _ = SaveStudentsToJson(saveStudents);
        _ = SaveTeachersToJson(saveTeachers);
    }

    public static int GetID(){
        int highID = -1;
        foreach (Person person in Data.People){
            highID = Math.Max(highID, person.UserID);
        }
        return highID;
    }
}