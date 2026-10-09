using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Services.Description;

namespace domRescueBus.Models
{
    public class DataRepository
    {
        // file path for storing booking data
        private static string BookingsFilePath => HttpContext.Current.Server.MapPath("~/App_Data/Bookings.json");

        // list of service types based on id
        public static List<ServiceType> GetServiceTypes()
        {
            return new List<ServiceType>
            {
                new ServiceType
                {
                    Id = 0,
                    Name = "All Services"
                },

                new ServiceType 
                { 
                    Id = 1, 
                    Name = "Advanced Life Support" 
                },

                new ServiceType 
                { 
                    Id = 2, 
                    Name = "Basic Life Support" 
                },
                
                new ServiceType 
                { 
                    Id = 3, 
                    Name = "Patient Support" 
                },
                
                new ServiceType 
                { 
                    Id = 4, 
                    Name = "Medical Utility Vehicle" 
                },
                
                new ServiceType 
                { 
                    Id = 5, 
                    Name = "Event Medical Ambulance" 
                },
                
                new ServiceType 
                { 
                    Id = 6, 
                    Name = "Air Ambulance" 
                }
            };
        }

        // list of initial driver details based on id
        public static List<Driver> GetInitialDrivers()
        {
            return new List<Driver>
            {
                new Driver 
                { 
                    Id = 1, 
                    Name = "Amy Addams", 
                    PhoneNumber = "+27 72 853 9941", 
                    Picture = "~/Content/Images/driver_1.jpg",
                    ServiceId = 1 
                },

                new Driver
                {
                    Id = 2,
                    Name = "Benjamin Blue",
                    PhoneNumber = "+27 73 123 4567",
                    Picture = "~/Content/Images/driver_2.jpg",
                    ServiceId = 1
                },

                new Driver
                {
                    Id = 3,
                    Name = "Charlie Clake",
                    PhoneNumber = "+27 74 234 5678",
                    Picture = "~/Content/Images/driver_3.jpg",
                    ServiceId = 2
                },

                new Driver
                {
                    Id = 4,
                    Name = "Danny Davis",
                    PhoneNumber = "+27 75 345 6789",
                    Picture = "~/Content/Images/driver_4.jpg",
                    ServiceId = 2
                },

                new Driver
                {
                    Id = 5,
                    Name = "Emmeline Evers",
                    PhoneNumber = "+27 76 456 7890",
                    Picture = "~/Content/Images/driver_5.jpg",
                    ServiceId = 3
                },

                new Driver
                {
                    Id = 6,
                    Name = "Freddy Fisher",
                    PhoneNumber = "+27 77 567 8901",
                    Picture = "~/Content/Images/driver_6.jpg",
                    ServiceId = 3
                },

                new Driver
                {
                    Id = 7,
                    Name = "Georgie Grant",
                    PhoneNumber = "+27 78 678 9012",
                    Picture = "~/Content/Images/driver_7.jpg",
                    ServiceId = 4
                },

                new Driver
                {
                    Id = 8,
                    Name = "Hannah Harrelson",
                    PhoneNumber = "+27 79 789 0123",
                    Picture = "~/Content/Images/driver_8.jpg",
                    ServiceId = 5
                },

                new Driver
                {
                    Id = 9,
                    Name = "Isabel Irving",
                    PhoneNumber = "+27 80 123 4567",
                    Picture = "~/Content/Images/driver_9.jpg",
                    ServiceId = 6
                },

                new Driver
                {
                    Id = 10,
                    Name = "Jamie Jacobs",
                    PhoneNumber = "+27 81 234 5678",
                    Picture = "~/Content/Images/driver_10.jpg",
                    ServiceId = 6
                },
            };
        }

        // list of current drivers
        public static List<Driver> GetDrivers()
        {
            return GetInitialDrivers();
        }

        // list of initial vehicle details based on id
        public static List<Vehicle> GetInitialVehicles()
        {
            return new List<Vehicle>
            {
                new Vehicle 
                { 
                    Id = 1, 
                    Type = "Rescue One", 
                    RegistrationNumber = "RSC001", 
                    Picture = "~/Content/Images/vehicle_1.jpg",
                    ServiceId = 1 
                },

                new Vehicle
                {
                    Id = 2,
                    Type = "Rescue Two",
                    RegistrationNumber = "RSC002",
                    Picture = "~/Content/Images/vehicle_2.jpg",
                    ServiceId = 2
                },

                new Vehicle
                {
                    Id = 3,
                    Type = "Rescue Three",
                    RegistrationNumber = "RSC003",
                    Picture = "~/Content/Images/vehicle_3.jpg",
                    ServiceId = 3
                },

                new Vehicle
                {
                    Id = 4,
                    Type = "Rescue Four",
                    RegistrationNumber = "RSC004",
                    Picture = "~/Content/Images/vehicle_4.jpg",
                    ServiceId = 4
                },

                new Vehicle
                {
                    Id = 5,
                    Type = "Rescue Bus",
                    RegistrationNumber = "RSCBUS",
                    Picture = "~/Content/Images/vehicle_5.jpg",
                    ServiceId = 5
                },

                new Vehicle
                {
                    Id = 6,
                    Type = "Rescue Air",
                    RegistrationNumber = "RSCAIR",
                    Picture = "~/Content/Images/vehicle_6.jpg",
                    ServiceId = 6
                },
            };
        }

        // list of current vehicles
        public static List<Vehicle> GetVehicles()
        {
            return GetInitialVehicles();
        }

        // helper function = reads and deserializes JSON data to list of objects
        private static List<T> ReadJsonFile<T>(string filePath)
        {
            if (!File.Exists(filePath))
            {
                return new List<T>();
            }
            string json = File.ReadAllText(filePath);
            return JsonConvert.DeserializeObject<List<T>>(json) ?? new List<T>();
        }

        // helper function = writes and serializes list of objects to JSON data
        private static void WriteJsonFile<T>(string filePath, List<T> data)
        {
            string directory = Path.GetDirectoryName(filePath);
            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }
            string json = JsonConvert.SerializeObject(data, Formatting.Indented);
            File.WriteAllText(filePath, json);
        }
        
        // booking management = saves booking to bookings JSON file
        public static void SaveBooking(Booking newBooking, string filePath)
        {
            List<Booking> bookings = new List<Booking>();

            if (newBooking.BookingId == Guid.Empty)
            {
                newBooking.BookingId = Guid.NewGuid();
            }

            bookings.Add(newBooking);
            WriteJsonFile(filePath, bookings);
        }
    }
}