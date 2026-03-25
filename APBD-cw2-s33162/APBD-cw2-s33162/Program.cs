using APBD_cw2_s33162.Models;
using APBD_cw2_s33162.Services;

namespace APBD_cw2_s33162;

internal class Program
{
    static void Main(string[] args)
    {
        RentalService service = new RentalService();

        Student student1 = new Student("Jan", "Kowalski");
        Student student2 = new Student("Anna", "Nowak");
        Employee employee1 = new Employee("Piotr", "Wisniewski");

        service.AddUser(student1);
        service.AddUser(student2);
        service.AddUser(employee1);

        Laptop laptop1 = new Laptop("Dell Latitude", "Intel i5", 16);
        Laptop laptop2 = new Laptop("HP ProBook", "Intel i7", 8);
        Projector projector1 = new Projector("Epson X200", 3500, "1920x1080");
        Camera camera1 = new Camera("Canon EOS", 24, true);
        Camera camera2 = new Camera("Nikon D3500", 20, false);

        service.AddEquipment(laptop1);
        service.AddEquipment(laptop2);
        service.AddEquipment(projector1);
        service.AddEquipment(camera1);
        service.AddEquipment(camera2);

        Console.WriteLine("START PROGRAMU");

        service.ShowAllEquipment();

        Console.WriteLine("\nPoprawne wypozyczenie:");
        service.RentEquipment(student1.Id, laptop1.Id, 7);

        Console.WriteLine("\nProba wypozyczenia tego samego sprzetu drugi raz:");
        service.RentEquipment(student2.Id, laptop1.Id, 5);

        Console.WriteLine("\nStudent wypozycza drugi sprzet:");
        service.RentEquipment(student1.Id, projector1.Id, 3);

        Console.WriteLine("\nStudent probuje przekroczyc limit wypozyczen:");
        service.RentEquipment(student1.Id, camera1.Id, 2);

        Console.WriteLine("\nDostepny sprzet:");
        service.ShowAvailableEquipment();

        Console.WriteLine("\nAktywne wypozyczenia studenta:");
        service.ShowActiveRentalsForUser(student1.Id);

        Console.WriteLine("\nOznaczenie sprzetu jako niedostepny:");
        service.MarkEquipmentAsUnavailable(camera2.Id);

        Console.WriteLine("\nZwrot sprzetu w terminie:");
        service.ReturnEquipment(projector1.Id);

        Console.WriteLine("\nSymulacja opoznionego zwrotu:");
        service.RentEquipment(employee1.Id, camera1.Id, -2);
        service.ReturnEquipment(camera1.Id);

        Console.WriteLine("\nPrzeterminowane wypozyczenia:");
        service.ShowOverdueRentals();

        Console.WriteLine("\nRaport koncowy:");
        service.ShowReport();

        Console.WriteLine("KONIEC PROGRAMU");
    }
}