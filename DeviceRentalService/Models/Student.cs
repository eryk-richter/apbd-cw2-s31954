using DeviceRentalService.Enums;
namespace DeviceRentalService.Models;

public class Student(string firstname, string lastname) 
    : User(firstname, lastname, UserType.Student) {

    public override int GetMaxRentals() => 2;
}