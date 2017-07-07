using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VehicleMonitorV1.Models
{
    public class Vehicle
    {
        public int ID { get; set; }
        public string RegistrationPlate { get; set; }
        public int DriverID { get; }
        public double Latitude
        {
            get { return -27.4698 + (new Random().NextDouble()) / 1000; }
        }
        public double Longtitude
        {
            get { return 153.0251 + (new Random().NextDouble()) / 1000; }
        }
        public double Altitude { get { return 0; } }
        public bool IsDriving { get; set; } = false;

        public static Vehicle GetAVehicleFromDB()
        {
            return new Vehicle { ID = 1 };
        }
    }

}