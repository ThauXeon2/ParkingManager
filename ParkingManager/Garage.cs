namespace ParkingManager
{
    public class Garage
    {
        private string _name;
        private int _capacity;
        private List<Vehicle> _vehicles;
        public string Name { get { return _name; } set { _name = value; } }
        public int Capacity { get { return _capacity; } }
        public List<Vehicle> Vehicles { get { return _vehicles; } }
        public Garage(string name, int capacity)
        {
            Name = name;
            _capacity = capacity;
            _vehicles = new();
        }
        public bool AddVehicle(Vehicle vehicle)
        {
            if (Vehicles.Count < _capacity)
            {
                _vehicles.Add(vehicle);
                return true;
            }
            else
                return false;
        }
        public Vehicle FindByPlate(string plate) => Vehicles.Where(x => x.Plate == plate).FirstOrDefault();
        public bool RemoveVehicle(string plate)
        {
            if (FindByPlate(plate) != null)
            {
                Vehicles.Remove(FindByPlate(plate));
                return true;
            }
            else
                return false;
        }
        public List<Vehicle> LowBalance() => Vehicles.Where(x => x.Balance < 1000).ToList();
        public int TotalHours() => Vehicles.Sum(x => x.HoursParked);
        public Vehicle LongestParked() => Vehicles.MaxBy(x => x.HoursParked);
        public double AverageHours(bool electric)
        {
            if (electric && Vehicles.Any(x => x.IsElectric))
                return Vehicles.Where(x => x.IsElectric).Average(y => y.HoursParked);
            if (!electric && Vehicles.Where(x => x.IsElectric == false).Any())
                return Vehicles.Where(x => x.IsElectric == false).Average(y => y.HoursParked);
            else
                return 0;
        }
    }
}
