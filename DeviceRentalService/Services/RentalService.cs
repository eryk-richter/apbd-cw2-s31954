using DeviceRentalService.Models;
using DeviceRentalService.Enums;
namespace DeviceRentalService.Services;

public class RentalService : IRentalService{

    public void CreateUser(string firstName, string lastName, UserType userType) {
        throw new NotImplementedException();
    }

    public void RentDevice(User user, Device device, DateTime from, DateTime to) {
        throw new NotImplementedException();
    }

    public List<Rental> GetUserRentals(User user) {
        throw new NotImplementedException();
    }

    public double ReturnDevice(User user, Device device, DateTime returnDate) {
        throw new NotImplementedException();
    }

    public List<Rental> GetOverdueRentals() {
        throw new NotImplementedException();
    }

    public string GenerateRaport() {
        throw new NotImplementedException();
    }

    public void CreateDevice() {
        throw new NotImplementedException();
    }

    public List<Device> GetAllDevices() {
        throw new NotImplementedException();
    }

    public List<Device> GetAvailableDevices() {
        throw new NotImplementedException();
    }

    public void ChangeDeviceStatus(Device device, DeviceStatus newStatus) {
        throw new NotImplementedException();
    }

    public DeviceStatus GetDeviceStatus(Device device) {
        throw new NotImplementedException();
    }
    
}