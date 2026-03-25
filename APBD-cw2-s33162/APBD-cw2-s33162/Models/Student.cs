using APBD_cw2_s33162.Enums;

namespace APBD_cw2_s33162.Models;

public class Student : User
{
    public Student(string firstName, string lastName) : base(firstName, lastName)
    {
        UserType = UserType.Student;
    }
}