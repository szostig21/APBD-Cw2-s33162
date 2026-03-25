using APBD_cw2_s33162.Enums;

namespace APBD_cw2_s33162.Models;

public class Employee : User
{
    public Employee(string firstName, string lastName) : base(firstName, lastName)
    {
        UserType = UserType.Employee;
    }
}