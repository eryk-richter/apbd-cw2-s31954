using DeviceRentalService.Enums;
namespace DeviceRentalService;

public class Student(string firstname, string lastname) 
    : User(firstname, lastname, UserType.Student) {

    public override int GetMaxRentals() => 2;
}