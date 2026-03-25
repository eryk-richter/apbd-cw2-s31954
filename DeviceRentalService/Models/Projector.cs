namespace DeviceRentalService.Models;

public class Projector(string name, int resolution, int brightnessInNits) : Device(name) {
    public int Resolution { get; } = resolution;
    public int BrightnessInNits { get; } = brightnessInNits;
    
}