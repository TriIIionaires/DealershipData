using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DealershipData.Models;

namespace DealershipData.Data
{
    public class CarData
    {
        private readonly ISqlDataAccess _db = new SqlDataAccess();

        public List<CarModel> ReadAllCars()
        {
            string sql = "SELECT car.ID, Make, Model, Year, MSRP, CityMPG, HighwayMPG, Seats, Horsepower, RPM, Cylinders, cylinderlayouts.cylinderlayout, Displacement, turbos.turbo, drivetrains.drivetrain, transmissions.transmission, Gears, fuels.fuel " +
               "FROM car " +
               "INNER JOIN fuels ON car.Fuel=fuels.ID " +
               "INNER JOIN transmissions ON car.Transmission=transmissions.ID " +
               "INNER JOIN cylinderlayouts ON car.CylinderLayout=cylinderlayouts.ID " +
               "INNER JOIN turbos ON car.Turbo=turbos.ID " +
               "INNER JOIN drivetrains ON car.DriveTrain=drivetrains.ID";

            IEnumerable<CarModel> result = _db.LoadData<CarModel, dynamic>(sql, new { });
            List<CarModel> cars = result.ToList();
            
            if (cars.Count > 0) return cars;
            return null;
        }

        public CarModel ReadCarByID(int id)
        {
            string sql = "SELECT * FROM car WHERE car.ID = @id";

            IEnumerable<CarModel> result = _db.LoadData<CarModel, dynamic>(sql, new { id });
            List<CarModel> cars = result.ToList();

            if (cars.Count > 0) return cars[0];
            return null;
        }

        public void CreateCar(CarModel car)
        {
            string sql = "INSERT INTO car (Make, Model, Year, MSRP, CityMPG, HighwayMPG, Seats, Horsepower, RPM, Cylinders, CylinderLayout, Displacement, Turbo, DriveTrain, Transmission, Gears, Fuel) VALUES (@Make, @Model, @Year, @MSRP, @CityMPG, @HighwayMPG, @Seats, @Horsepower, @RPM, @Cylinders, @CylinderLayout, @Displacement, @Turbo, @DriveTrain, @Transmission, @Gears, @Fuel)";

            _db.SaveData(sql, car);
        }

        public void UpdateCar(CarModel car)
        {
            string sql = "UPDATE car SET Make = @Make, Model = @Model, Year = @Year, MSRP = @MSRP, CityMPG = @CityMPG, HighwayMPG = @HighwayMPG, Seats = @Seats, Horsepower = @Horsepower, RPM = @RPM, Cylinders = @Cylinders, CylinderLayout = @CylinderLayout, Displacement = @Displacement, Turbo = @Turbo, DriveTrain = @DriveTrain, Transmission = @Transmission, Fuel = @Fuel WHERE car.ID = @ID";

            _db.SaveData(sql, car);
        }

        public void DeleteCar(int id)
        {
            string sql = "DELETE FROM car WHERE car.ID = @id";

            _db.SaveData(sql, new { id });
        }

        /*public List<GenreModel> GetMovieGenres(int id)
        {
            string sql = "SELECT genres.genre FROM genres INNER JOIN asgngenre ON genres.genreID = asgngenre.genreID WHERE asgngenre.movieID = @id";

            List<GenreModel> result = _db.LoadData<GenreModel, dynamic>(sql, new { id });

            if (result.Count > 0) return result;
            return null;
        }

        public List<string> GetMovieGenres(int id)
        {
            string sql = "SELECT genres.genre FROM genres INNER JOIN asgngenre ON genres.genreID = asgngenre.genreID WHERE asgngenre.movieID = @id";

            List<string> result = _db.LoadData<string, dynamic>(sql, new { id });
            
            if (result.Count > 0) return result;
            return null;
        }*/
    }
}
