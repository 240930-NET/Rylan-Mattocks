namespace WebRoster.Models;
public class UserDetail{
    public int ID {get; set;}
    public int UserID {get; set;}
    public DateTime DateOfBirth {get; set;}
    public string Address {get; set;}
    public User User {get; set;}
}