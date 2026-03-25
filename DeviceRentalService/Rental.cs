using DeviceRentalService.Enums;

namespace  DeviceRentalService;

public class Rental(Device device, User user, DateTime from, DateTime to) {
    private static int _nextId = 1;
    
    public int Id { get; }  = _nextId++;
    public Device Device { get; set; }  = device;
    public User User { get; set; }  = user;
    public DateTime From { get; set; } = from >= to ? throw new ArgumentException("Invalid time range") : from;
    public DateTime To { get; set; } = to;
    public RentalStatus Status { get; set; } = RentalStatus.Open;

    public DateTime? ReturnTime { get; set; } = null;
    public double OverdueFeeByDay { get; } = 14.99;
}