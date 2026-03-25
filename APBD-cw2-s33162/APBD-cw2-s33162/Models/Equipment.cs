using APBD_cw2_s33162.Enums;

namespace APBD_cw2_s33162.Models;

public abstract class Equipment
{
    private static int nextId = 1;
    
    public int Id { get; set; }
    public string Name { get; set; }
    public EquipmentStatus Status { get; set; }
    
    public Equipment(string name)
    {
        Id = nextId++;
        Name = name;
        Status = EquipmentStatus.Available;
    }

    public override string ToString()
    {
        return $"ID: {Id}, Name: {Name}, Status: {Status}";
    }
}