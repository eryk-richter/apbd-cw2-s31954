namespace DeviceRentalService.Exceptions;

public class RentalLimitReachedException(string message) : Exception(message);