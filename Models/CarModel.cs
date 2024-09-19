using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace DealershipData.Models
{
    public class CarModel
    {

        public enum Transmissions
        {
            Automatic = 1,
            Manual = 2,
            Semi_Automatic = 3,
            DCT = 4,
            CVT = 5,
            eCVT = 6,
            iMT = 7,
            Direct_Drive = 8
        }

        public enum FuelTypes
        {
            Gasoline = 1,
            Electric = 2,
            Hybrid = 3,
            Diesel = 4
        }

        public enum Turbos
        {
            None = 0,
            Turbo = 1,
            Twin_Turbo = 2,
            Triple_Turbo = 3,
            Quad_Turbo = 4,
            Supercharged = 5
        }

        public enum DriveTrains
        {
            RWD = 1,
            FWD = 2,
            AWD = 3,
            FourWD = 4
        }

        public enum CylinderLayouts
        {
            None = 0,
            Inline = 1,
            Flat = 2,
            V = 3,
            W = 4,
            Rotary = 5
        }

        public int ID { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public int MSRP { get; set; }
        public int CityMPG { get; set; }
        public int HighwayMPG { get; set; }
        public int Seats { get; set; }
        public int Horsepower { get; set; }
        public int RPM { get; set; }
        public int Cylinders { get; set; }
        public CylinderLayouts CylinderLayout { get; set; }
        public double Displacement { get; set; }
        public Turbos Turbo { get; set; }
        public DriveTrains DriveTrain { get; set; }
        public Transmissions Transmission { get; set; }
        public int Gears { get; set; }
        public FuelTypes Fuel { get; set; }

        public override string ToString()
        {
            string output;
            output = $"{ID}: {Year:0000} {Make} {Model}\nMSRP: ${MSRP:n0}\nMPG: {CityMPG} city / {HighwayMPG} highway\nSeating: {Seats} seats\n";

            if (Fuel == FuelTypes.Electric) //Excludes Displacement, Cylinders, RPM for Electric Cars
            {
                output += $"Engine: Electric ({DriveTrain})\nPower: {Horsepower} hp\n";
            } else
            {
                output += $"Engine: {Displacement:0.0} L ";

                if (CylinderLayout == CylinderLayouts.V || CylinderLayout == CylinderLayouts.W) //Excludes Dash for V-type and W-type engines
                {
                    output += $"{CylinderLayout}{Cylinders} ";
                } else
                {
                    output += $"{CylinderLayout}-{Cylinders} ";
                }

                if (Turbo != Turbos.None) //Includes Turbo
                {
                    output += $"{Turbo.ToString().Replace("_", " ")} ";
                }
                                
                output += $"({DriveTrain})\nPower: {Horsepower} hp @ {RPM} rpm\n";
            }

            if (Transmission == Transmissions.CVT || Transmission == Transmissions.eCVT || Transmission == Transmissions.Direct_Drive) //Excludes Gears
            {
                output += $"Transmission: {Transmission.ToString().Replace("_", "-")}\n";
            } else
            {
                output += $"Transmission: {Gears}-speed {Transmission.ToString().Replace("_", "-")}\n";
            }
            
            output += $"Fuel: {Fuel}\n";
            return output;
        }
    }
}