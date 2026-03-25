using DeviceRentalService.Enums;

namespace DeviceRentalService.Models;

public class Camera(string name, CameraType cameraType, bool lensIncluded) : Device(name) {
    public CameraType CameraType { get; } = cameraType;
    public bool LensIncluded { get; } = lensIncluded;
}