namespace DeviceRentalService.Models;

public class Laptop (string name, int ramCapacity, int ssdCapacity) 
    : Device(name) {
    
    public int RamCapacity { get; } = ramCapacity;
    public int SsdCapacity { get; } = ssdCapacity;
}