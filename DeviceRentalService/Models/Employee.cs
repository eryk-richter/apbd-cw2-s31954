using DeviceRentalService.Enums;

namespace DeviceRentalService.Models;

public class Employee(string firstname, string lastname)
    : User(firstname, lastname, UserType.Employee) {

    public override int GetMaxRentals() => 5;
}