# RescueBus

An ASP.NET MVC web app for booking emergency and medical transport. Users choose a service, are matched with an available driver and vehicle, and can track past rides. There is also a one-tap SOS button for emergencies.

Built for INF 272 at the University of Pretoria.

## Features

- **SOS button**: books an emergency ride straight from the home page.
- **Book a service**: choose a service type, then pick from the drivers and vehicles assigned to that service. The lists load dynamically for the selected service.
- **Booking confirmation**: shows the booking details with the driver's and vehicle's photos.
- **Ride history**: lists past bookings as cards, with SOS bookings highlighted.
- **Management**: view all drivers, vehicles and service types, and export the vehicle list to a text file.

## Tech stack

- ASP.NET MVC 5 on .NET Framework 4.7.2 (C#)
- Razor views, Bootstrap 5 and jQuery
- No database: drivers, vehicles and services are defined in code (`DataRepository.cs`), and bookings are saved to `App_Data/Bookings.json`

## Running locally

1. Open `domRescueBus.sln` in Visual Studio 2022 with the **ASP.NET and web development** workload installed.
2. Press **F5**. NuGet packages are restored automatically on the first build.

No database setup is needed.

## Project structure

```
domRescueBus/
├── Controllers/
│   ├── HomeController.cs       # Home, ride history, management and export
│   └── ServicesController.cs   # Service selection and booking
├── Models/
│   ├── DataRepository.cs       # Drivers, vehicles, services and booking storage
│   └── Booking.cs, Driver.cs, Vehicle.cs, ...
├── Views/
└── App_Data/Bookings.json      # Saved bookings
```
