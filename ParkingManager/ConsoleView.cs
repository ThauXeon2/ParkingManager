namespace ParkingManager
{
    public class ConsoleView
    {
        public static void ShowVehicle(Vehicle vehicle) => Console.WriteLine(vehicle.GetDescription());
        public static void ShowVehicles(List<Vehicle> vehicles) => vehicles.ForEach(x => Console.WriteLine(x.GetDescription()));
        public static void ShowMessage(string message) => Console.WriteLine(message);
    }
}
