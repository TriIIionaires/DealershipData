using DealershipData.Data;
using DealershipData.Models;

namespace DealershipData
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CarData _db = new CarData();

            /*CarModel car1 = new CarModel()
            {
                ID = 3,
                Make = "BMW",
                Model = "i4 M50",
                Year = 2022,
                MSRP = 67000,
                CityMPG = 79,
                HighwayMPG = 80,
                Seats = 5,
                Horsepower = 536,
                RPM = 5600,
                Cylinders = 6,
                CylinderLayout = CarModel.CylinderLayouts.Flat,
                Displacement = 3.0,
                Turbo = CarModel.Turbos.Twin_Turbo,
                DriveTrain = CarModel.DriveTrains.AWD,
                Transmission = CarModel.Transmissions.Automatic,
                Gears = 6,
                Fuel = CarModel.FuelTypes.Gasoline
            };

            Console.WriteLine(car1);

            
            _db.UpdateCar(car1);*/

            List<CarModel> cars = _db.ReadAllCars();

            foreach (CarModel car in cars)
            {
                Console.WriteLine(car);
            }
                        
        }
    }
}
