namespace APBD_cw2_s33162.Models;

public class Projector : Equipment
{
    public int Brightness { get; set; }
    public string Resolution { get; set; }

    public Projector(String name, int brightness, string resolution) : base(name)
    {
        Brightness = brightness;
        Resolution = resolution;
    }

    public override string ToString()
    {
        return base.ToString() + $", Type: Projector, Brightness: {Brightness}, Resolution: {Resolution}";
    }
}