using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace VehicleMonitorV1.Models
{
    public class Vehicle
    {
        public int ID { get; set; }
        public string RegistrationPlate { get; set; }
        public int DriverID { get; }
        public double Latitude
        {
            get;set;
        }
        public double Longitude
        {
            get;set;
        }
        public double Altitude { get { return 0; } }
        public bool IsDriving { get; set; } = false;

        public static Vehicle GetAVehicleFromDB()
        {
            return new Vehicle { ID = 1 };
        }
        private static string _userName = "silversr";
        private static string _password = "diskedit7_SR";
        public static Vehicle GetVehicleFromDB(string registrationPlate) 
        {
            Vehicle aCar = new Vehicle { ID = 1 };
            //await Task.Run();
            try
            {
                string connectString = "Server = tcp:vehiclemonitorv1db-server.database.windows.net,1433;"
                    + "Initial Catalog = VehicleMonitorV1DB; Persist Security Info = False;"
                    + $"User ID = {_userName}; Password ={_password}; MultipleActiveResultSets = False; Encrypt = True;"
                    + "TrustServerCertificate = False; Connection Timeout = 30;";
                using (SqlConnection connection = new SqlConnection(connectString))
                //SqlConnection connection = new SqlConnection(connectString);
                {
                    connection.Open();
                    //this._connection = connection;
                    StringBuilder sb = new StringBuilder();
                    sb.Append("SELECT RegistrationPlate, Latitude, Longitude FROM VehicleMonitorV1DB.dbo.Vehicles ");
                    sb.Append($"WHERE RegistrationPlate = @registrationPlate;");

                    string sql = sb.ToString();
                    Console.WriteLine(sql);
                    using (SqlCommand cmd = new SqlCommand(sql, connection))
                    {
                        cmd.Parameters.AddWithValue("@registrationPlate", registrationPlate);
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                aCar.RegistrationPlate = reader.GetString(0);
                                aCar.Latitude = reader.GetDouble(1);
                                aCar.Longitude = reader.GetDouble(2);
                            }
                        }
                    }
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.ToString());
            }
            return aCar;
        }

    }

}