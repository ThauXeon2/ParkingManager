namespace ParkingManager
{
    public class Vehicle
    {
        private string _plate;
        private int _year;
        private bool _isElectric;
        public string Plate { get { return _plate; } set { _plate = value; } }
        public int Year { get { return _year; } set { _year = value is >= 1990 and <= 2026 ? value : 0; } }
        public bool IsElectric { get { return _isElectric; } set { _isElectric = value; } }
        private static int _count;
        public static int Count { get { return _count; } }
        public Vehicle(string plate, int year, bool isElectric)
        {
            Plate = plate;
            Year = year;
            IsElectric = isElectric;
            _count++;
        }
        private int _balance;
        private int _hoursParked;
        public int Balance { get { return _balance; } }
        public int HoursParked { get { return _hoursParked; } }
        public bool TopUp(int amount)
        {
            if (amount == 1000 || amount == 2000 || amount == 5000)
            {
                _balance += amount;
                return true;
            }
            else
                return false;

        }
        public bool Park(int hours)
        {
            if (IsElectric && hours >= 1)
            {
                if (_balance - ParkingFee(hours, IsElectric) >= 0)
                {
                    _balance -= ParkingFee(hours, IsElectric);
                    _hoursParked += hours;
                    return true;
                }
                else
                    return false;
            }
            if (!IsElectric && hours >= 1)
            {
                if (_balance - ParkingFee(hours, IsElectric) >= 0)
                {
                    _balance -= ParkingFee(hours, IsElectric);
                    _hoursParked += hours;
                    return true;
                }
                else
                    return false;
            }
            else
                return false;
        }
        public string GetDescription() => $"{Plate} ({(Year == 0 ? "Ismeretlen évjárat" : Year)}, {(IsElectric ? "Elektromos" : "Hagyományos")}): {_balance} Ft egyenleg, {_hoursParked} óra parkolás";
        public static int ParkingFee(int hours, bool isElectric)
        {
            if (isElectric && hours > 0)
            {
                return hours < 5 ? hours * 200 : (int)(hours * 200 * 0.8);
            }
            if (!isElectric && hours > 0)
            {
                return hours < 5 ? hours * 400 : (int)(hours * 400 * 0.8);
            }
            else
                return 0;
        }
    }
}
