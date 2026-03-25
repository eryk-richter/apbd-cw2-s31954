namespace DeviceRentalService;
using Enums;

public abstract class User(int id, string firstname, string lastname, UserType userType) {
    private static int _nextId = 1;
    
    public int Id { get; } = _nextId++;
    public string Firstname { get; } =  firstname;
    public string Lastname { get; } =  lastname;
    public UserType UserType { get; } = userType;

}

