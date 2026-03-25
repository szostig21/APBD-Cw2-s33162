namespace APBD_cw2_s33162.Models;

public class Camera : Equipment
{
    public int Pixels { get; set; }
    public bool IsRecording { get; set; }

    public Camera(string name, int pixels, bool isRecording) : base(name)
    {
        Pixels = pixels;
        IsRecording = isRecording;
    }

    public override string ToString()
    {
        return base.ToString() + $",Type: Camera, Pixels: {Pixels}, Recording: {IsRecording}";
    }
}