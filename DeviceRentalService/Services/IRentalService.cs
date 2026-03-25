using DeviceRentalService.Enums;
using DeviceRentalService.Models;
namespace DeviceRentalService.Services;

public interface IRentalService {
    public void CreateUser(string firstName, string lastName, UserType userType);
    public void RentDevice(User user, Device device, DateTime from, DateTime to);
    public List<Rental> GetUserRentals(User user);
    public double ReturnDevice(User user, Device device, DateTime returnDate); 
    public List<Rental> GetOverdueRentals();
    public string GenerateRaport();
    public void CreateDevice();
    public List<Device> GetAllDevices();
    public List<Device> GetAvailableDevices();
    public void ChangeDeviceStatus(Device device,  DeviceStatus newStatus);
    public DeviceStatus GetDeviceStatus(Device device);
}