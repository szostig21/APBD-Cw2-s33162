using APBD_cw2_s33162.Enums;

namespace APBD_cw2_s33162.Models;

public abstract class User
{
    private static int nextId = 1;
    
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public UserType UserType { get; set; }

    public User(String firstName, String lastName)
    {
        Id = nextId++;
        FirstName = firstName;
        LastName = lastName;
    }

    public override string ToString()
    {
        return $"ID: {Id}, {FirstName} {LastName}, Type: {UserType}";
    }
}