using DeviceRentalService.Enums;

namespace DeviceRentalService;

public class Employee(string firstname, string lastname)
    : User(firstname, lastname, UserType.Employee) {

    public override int GetMaxRentals() => 5;
}