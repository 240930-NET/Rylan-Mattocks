namespace Roster.APP;
public abstract class Person{
    public string? FirstName {get; set;}
    public string? LastName {get; set;}
    public int Age {get; set;}
    public int UserID {get; set;}
    public int NextID {get; set;} = 0;
}