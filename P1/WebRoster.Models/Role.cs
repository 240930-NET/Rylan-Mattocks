namespace WebRoster.Models;
public class Role{
    public int ID {get; set;}
    public string RoleName {get; set;}
    public List<User> Users {get; set;}
    /*public PersonType(){}

    public PersonType(string type){
        this.Type = type;
    }*/
}