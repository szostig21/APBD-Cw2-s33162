using APBD_cw2_s33162.Enums;
using APBD_cw2_s33162.Models;

namespace APBD_cw2_s33162.Services;

public class RentalService
{
    private List<User> _users = new List<User>();
    private List<Equipment> _equipment = new List<Equipment>();
    private List<Rental> _rentals = new List<Rental>();

    private const int StudentLimit = 2;
    private const int EmployeeLimit = 5;
    private const decimal PenaltyPerDay = 10m;

    public void AddUser(User user)
    {
        _users.Add(user);
    }

    public void AddEquipment(Equipment equipment)
    {
        _equipment.Add(equipment);
    }

    public List<Equipment> GetAllEquipment()
    {
        return _equipment;
    }

    public List<Equipment> GetAvailableEquipment()
    {
        return _equipment.Where(e => e.Status == EquipmentStatus.Available).ToList();
    }

    public List<Rental> GetActiveRentalsForUser(int userId)
    {
        return _rentals.Where(r => r.User.Id == userId && !r.IsReturned).ToList();
    }

    public List<Rental> GetOverdueRentals()
    {
        return _rentals.Where(r => !r.IsReturned && DateTime.Now > r.DueDate).ToList();
    }

    public bool RentEquipment(int userId, int equipmentId, int days)
    {
        User? user = _users.FirstOrDefault(u => u.Id == userId);
        Equipment? equipment = _equipment.FirstOrDefault(e => e.Id == equipmentId);

        if (user == null || equipment == null)
        {
            Console.WriteLine("User or equipment not found");
            return false;
        }
        if (equipment.Status != EquipmentStatus.Available)
        {
            Console.WriteLine("Equipment is not available");
            return false;
        }
        int activeRentals = _rentals.Count(r => r.User.Id == userId && !r.IsReturned);
        int limit = user.UserType == UserType.Student ? StudentLimit : EmployeeLimit;

        if (activeRentals >= limit)
        {
            Console.WriteLine("User has reached rental limit");
            return false;
        }

        Rental rental = new Rental(user, equipment, DateTime.Now, DateTime.Now.AddDays(days));
        _rentals.Add(rental);
        equipment.Status = EquipmentStatus.Rented;
        Console.WriteLine("Equipment rented successfully");
        return true;
    }

    public bool ReturnEquipment(int equipmentId)
    {
        Rental? rental = _rentals.FirstOrDefault(r => r.Equipment.Id == equipmentId && !r.IsReturned);
        if (rental == null)
        {
            Console.WriteLine("Active rental not found");
            return false;
        }

        rental.ReturnDate = DateTime.Now;
        rental.Equipment.Status = EquipmentStatus.Available;
        if (rental.ReturnDate.Value > rental.DueDate)
        {
            int lateDays = (rental.ReturnDate.Value - rental.DueDate).Days;

            if (lateDays < 1)
            {
                lateDays = 1;
            }

            rental.Penalty = lateDays * PenaltyPerDay;
        }

        Console.WriteLine($"Equipment returned - Penalty: {rental.Penalty}");
        
        return true;
    }

    public bool MarkEquipmentAsUnavailable(int equipmentId)
    {
        Equipment? equipment = _equipment.FirstOrDefault(e => e.Id == equipmentId);

        if (equipment == null)
        {
            Console.WriteLine("Equipment not found");
            return false;
        }

        if (equipment.Status == EquipmentStatus.Rented)
        {
            Console.WriteLine("Cannot mark rented equipment as unavailable");
            return false;
        }

        equipment.Status = EquipmentStatus.Unavailable;
        Console.WriteLine("Equipment marked as unavailable");
        
        return true;
    }

    public void ShowAllEquipment()
    {
        Console.WriteLine("\nAll equipment:");
        foreach (var item in _equipment)
        {
            Console.WriteLine(item);
        }
    }

    public void ShowAvailableEquipment()
    {
        Console.WriteLine("\nAvailable equipment:");
        foreach (var item in GetAvailableEquipment())
        {
            Console.WriteLine(item);
        }
    }

    public void ShowActiveRentalsForUser(int userId)
    {
        Console.WriteLine($"\nActive rentals for user {userId}:");
        foreach (var rental in GetActiveRentalsForUser(userId))
        {
            Console.WriteLine(rental);
        }
    }

    public void ShowOverdueRentals()
    {
        Console.WriteLine("\nOverdue rentals:");
        foreach (var rental in GetOverdueRentals())
        {
            Console.WriteLine(rental);
        }
    }

    public void ShowReport()
    {
        Console.WriteLine("\nREPORT");
        Console.WriteLine($"Total equipment: {_equipment.Count}");
        Console.WriteLine($"Available equipment: {_equipment.Count(e => e.Status == EquipmentStatus.Available)}");
        Console.WriteLine($"Rented equipment: {_equipment.Count(e => e.Status == EquipmentStatus.Rented)}");
        Console.WriteLine($"Unavailable equipment: {_equipment.Count(e => e.Status == EquipmentStatus.Unavailable)}");
        Console.WriteLine($"Total users: {_users.Count}");
        Console.WriteLine($"Active rentals: {_rentals.Count(r => !r.IsReturned)}");
        Console.WriteLine($"Overdue rentals: {_rentals.Count(r => !r.IsReturned && DateTime.Now > r.DueDate)}");
        Console.WriteLine("\n");
    }
}