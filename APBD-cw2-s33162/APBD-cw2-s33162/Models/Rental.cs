namespace APBD_cw2_s33162.Models;

public class Rental
{
    public User User  { get; set; }
    public Equipment Equipment { get; set; }
    public DateTime RentalDate { get; set; }
    public DateTime DueDate { get; set; }
    public DateTime? ReturnDate { get; set; }
    public decimal Penalty { get; set; }
    
    public bool IsReturned => ReturnDate.HasValue;
    public bool IsOverdue => !IsReturned && DateTime.Now > DueDate;

    public Rental(User user, Equipment equipment, DateTime rentalDate, DateTime dueDate)
    {
        User = user;
        Equipment = equipment;
        RentalDate = rentalDate;
        DueDate = dueDate;
        ReturnDate = null;
        Penalty = 0;
    }

    public override string ToString()
    {
        string returnInfo = IsReturned ? ReturnDate.ToString()! : "Not returned";
        return $"User: {User.FirstName} {User.LastName}, Equipment: {Equipment.Name}, RentalDate: {RentalDate}, DueDate: {DueDate}, ReturnDate: {returnInfo}, Penalty: {Penalty}";
    }
}