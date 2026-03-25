namespace APBD_cw2_s33162.Models;

public class Laptop : Equipment
{
    public string Processor { get; set; }
    public int Ram { get; set; }

    public Laptop(string name, string processor, int ram) : base(name)
    {
        Processor = processor;
        Ram = ram;
    }

    public override string ToString()
    {
        return base.ToString() + $", Type: Laptop, Processor: {Processor}, RAM: {Ram}";
    }
}