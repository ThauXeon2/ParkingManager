namespace ParkingManager
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Vehicle vehicle1 = new("ABC-123", 2026, false);
            Vehicle vehicle2 = new("ABC-234", 2026, true);
            Vehicle vehicle3 = new("ABC-345", 1989, false);
            Vehicle vehicle4 = new("ABC-456", 1988, true);
            vehicle1.TopUp(5000);
            vehicle3.TopUp(2000);
            if (!vehicle4.TopUp(500))
                ConsoleView.ShowMessage("naur(jó válasz)");
            if (vehicle2.TopUp(1000))
                ConsoleView.ShowMessage("yup(jó válasz x2)");
            if (vehicle1.Park(4))
                ConsoleView.ShowMessage("yup(jó válasz x3)");
            if (!vehicle4.Park(1))
                ConsoleView.ShowMessage("naur(jó válasz x4)");
            if (!vehicle2.Park(15))
                ConsoleView.ShowMessage("naur(jó válasz x5)");
            ConsoleView.ShowVehicle(vehicle1);
            ConsoleView.ShowVehicle(vehicle2);
            ConsoleView.ShowVehicle(vehicle3);
            ConsoleView.ShowVehicle(vehicle4);
            ConsoleView.ShowMessage(Vehicle.Count.ToString());
            Garage garage = new("garázsnévfr", 3);
            garage.AddVehicle(vehicle1);
            garage.AddVehicle(vehicle2);
            garage.AddVehicle(vehicle3);
            if (!garage.AddVehicle(vehicle4))
                ConsoleView.ShowMessage("naur(jó válasz x6)");
            ConsoleView.ShowMessage("-------------------------");
            ConsoleView.ShowMessage(garage.Name);
            ConsoleView.ShowMessage(garage.Capacity.ToString());
            ConsoleView.ShowVehicles(garage.Vehicles);
            ConsoleView.ShowMessage("-------------------------");
            if (garage.FindByPlate("ABC-123") != null)
                ConsoleView.ShowVehicle(garage.FindByPlate("ABC-123"));
            if (garage.FindByPlate("ABC-127") != null)
                ConsoleView.ShowVehicle(garage.FindByPlate("ABC-127"));
            ConsoleView.ShowMessage("-------------------------");
            garage.RemoveVehicle("ABC-123");
            garage.AddVehicle(vehicle4);
            ConsoleView.ShowVehicles(garage.Vehicles);
            ConsoleView.ShowMessage("-------------------------");
            ConsoleView.ShowVehicles(garage.LowBalance());
            ConsoleView.ShowMessage(garage.TotalHours().ToString());
            if (garage.LongestParked() != null)
                ConsoleView.ShowVehicle(garage.LongestParked());
            ConsoleView.ShowMessage("-------------------------");
            ConsoleView.ShowMessage(Vehicle.ParkingFee(2, true).ToString());
            ConsoleView.ShowMessage(Vehicle.ParkingFee(6, true).ToString());
            ConsoleView.ShowMessage(Vehicle.ParkingFee(2, false).ToString());
            ConsoleView.ShowMessage(Vehicle.ParkingFee(6, false).ToString());
            ConsoleView.ShowMessage("-------------------------");
            ConsoleView.ShowMessage(garage.AverageHours(true).ToString());
            ConsoleView.ShowMessage(garage.AverageHours(false).ToString());
        }
    }
}
