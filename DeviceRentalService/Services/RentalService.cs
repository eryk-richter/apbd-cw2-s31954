using DeviceRentalService.Models;
using DeviceRentalService.Enums;
using DeviceRentalService.Exceptions;

namespace DeviceRentalService.Services;

public class RentalService : IRentalService{
    private List<User> _users = [];
    private List<Device> _devices = [];
    private List<Rental> _rentals = [];

    public void CreateUser(string firstName, string lastName, UserType userType) {
        if (userType == UserType.Student) {
            _users.Add(new Student(firstName, lastName));
        }
        _users.Add(new Employee(firstName, lastName));
    }
    
    public void RentDevice(User user, Device device, DateTime from, DateTime to) {
        if (GetUserRentals(user).Count > user.GetMaxRentals()) throw new RentalLimitReachedException("Rental limit reached");
        
        if ( device.Status != DeviceStatus.Available) throw new DeviceNotAvailableException("Device not available");
        
        _rentals.Add(new Rental(device, user, from, to));
        
    }

    public List<Rental> GetUserRentals(User user) {
        return _rentals.FindAll(n => n.User == user);
    }

    public double ReturnDevice(User user, Device device, DateTime returnDate) {
        var r = _rentals.Find(n => n.User == user && n.Device == device && n.Status == RentalStatus.Open);
        if (r == null) {
            throw new DeviceNotFoundException("Device not found");
        }
        
        r.ReturnTime = returnDate; 
        r.Status = RentalStatus.Closed;


        if (returnDate > r.To) {
            var diff = (returnDate - r.To);
            var lateDays = (int)Math.Ceiling(diff.TotalDays);
            
            return lateDays * r.OverdueFeeByDay;
        }
        
        return 0;
    }

    public List<Rental> GetOverdueRentals() {
        return _rentals.FindAll(r => r.ReturnTime == null);
    }

    public string GenerateRaport() {
        return "Raport";
    }

    public void CreateDevice(Device device) {
        _devices.Add(device);
    }

    public List<Device> GetAllDevices() {
        return _devices;
    }

    public List<Device> GetAvailableDevices() {
        return _devices.FindAll(n => n.Status == DeviceStatus.Available);
    }

    public void ChangeDeviceStatus(Device device, DeviceStatus newStatus) {
        device.Status = newStatus;
    }

    public DeviceStatus GetDeviceStatus(Device device) {
        return device.Status;
    }

    public List<User> GetUsersOverdue() {
        return GetOverdueRentals().ConvertAll(n => n.User).Distinct().ToList();
    }

    public List<User> GetAllUsers() {
       return _users; 
    }
}