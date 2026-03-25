using DeviceRentalService.Exceptions;

namespace DeviceRentalService;
using Models;
using Enums;
using Services;


public class Program
{

    public static void Main(String[] args) {
        Laptop laptop1 = new Laptop("lenovo thinkpad", 32, 512);
        Laptop laptop2 = new Laptop("lenovo ideapad", 16, 128);
        Laptop laptop3 = new Laptop("apple macbook pro", 24, 1024);

        Projector projector1 = new Projector("chinczyk",1080, 1000);
        Projector projector2 = new Projector("Samsung",1440, 1500);


        Camera camera1 = new Camera("Nikon fm2", CameraType.Slr, true);
        Camera camera2 = new Camera("Nikon D850", CameraType.Dslr, true);
        Camera camera3 = new Camera("Nikon Zf", CameraType.Mirrorless, true);
        
        
        RentalService rentalService = new RentalService();
        
        rentalService.CreateDevice(laptop1);
        rentalService.CreateDevice(laptop2);
        rentalService.CreateDevice(laptop3);
        rentalService.CreateDevice(camera1);
        rentalService.CreateDevice(camera2);
        rentalService.CreateDevice(camera3);
        rentalService.CreateDevice(projector1);
        rentalService.CreateDevice(projector2);
        
        rentalService.CreateUser("Jan", "Kowalski", UserType.Employee);
        rentalService.CreateUser("Janina", "Nowak", UserType.Employee);
        
        rentalService.CreateUser("Jakub", "Jakistam", UserType.Student);
        rentalService.CreateUser("Karolina", "BezNawy", UserType.Student);

        var users = rentalService.GetAllUsers();
        var devices = rentalService.GetAllDevices();
        
        rentalService.RentDevice(users[0], devices[0], new DateTime(2026,3,20), new DateTime(2026,3, 27));
        rentalService.RentDevice(users[0], devices[1], new DateTime(2026,3,20), new DateTime(2026,3, 27));

        
        // Proba wypozyczenia niedostepnego uzadzenia
        try {
            rentalService.RentDevice(users[2], devices[0], new DateTime(2026, 3, 20), new DateTime(2026, 3, 27));
        }
        catch (DeviceNotAvailableException ex) {
            Console.WriteLine(ex.Message);
        }

        rentalService.RentDevice(users[2], devices[3], new DateTime(2026, 3, 20), new DateTime(2026, 3, 27));
        rentalService.RentDevice(users[2], devices[4], new DateTime(2026, 3, 20), new DateTime(2026, 3, 27));
        

        
        
        // przekroczenie limitu
        try {
            
            rentalService.RentDevice(users[2], devices[5], new DateTime(2026, 3, 20), new DateTime(2026, 3, 27));
        }
        catch (RentalLimitReachedException ex) {
            Console.WriteLine(ex.Message);
        }
        
        // zwrot w terminie
        rentalService.ReturnDevice(users[2], devices[3], new DateTime(2026, 3, 25));
        
        // zwrot po terminie
        var fee = rentalService.ReturnDevice(users[2], devices[4], new DateTime(2026, 3, 29));
        Console.WriteLine("Opłata " + fee);
        
        
        Console.WriteLine(rentalService.GenerateRaport());
    }
    
    
}
