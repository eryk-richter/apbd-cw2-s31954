using DeviceRentalService.Enums;

namespace DeviceRentalService.Models;

public abstract class Device (string name){
    private static int _nextId = 1;
    
    public int Id { get; }  = _nextId++;
    public string Name { get; set; } = name;
    public DeviceStatus Status { get; set; } = DeviceStatus.Available;
}