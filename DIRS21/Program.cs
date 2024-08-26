using DIRS21.Mapper;
using DIRS21.Partners.Internal;
using GoogleReservation = DIRS21.Partners.Google.Reservation;
using AirbnbReservation = DIRS21.Partners.Airbnb.Reservationn;

MapperConfigurationHandler.LoadConfiguration();

var internalReservation1 = new Reservation()
{
    Id = "G-001",
    FirstName = "Jon",
    LastName = "Smith",
    RoomId = "RM-0207",
    From = DateTime.UtcNow.AddDays(30),
    To = DateTime.UtcNow.AddDays(31)
};

MapHandler _mapHandler = new();
var googleReservation1 = _mapHandler.Map(internalReservation1, "Model.Reservation", "Google.Reservation");

var googleReservation2 = new GoogleReservation()
{
    Id = "G-003",
    Name = "Jef Len",
    RoomId = "RM-0307",
    From = DateTime.UtcNow.AddDays(40),
    To = DateTime.UtcNow.AddDays(43),
    Notes = "Sample Notes"
};

var internalReservation2 = _mapHandler.Map(googleReservation2, "Google.Reservation", "Model.Reservation");

var internalReservation3 = new Reservation()
{
    Id = "G-001",
    FirstName = "Jon",
    LastName = "Smith",
    RoomId = "RM-0207",
    From = DateTime.UtcNow.AddDays(30),
    To = DateTime.UtcNow.AddDays(31)
};

var airbnbReservationn = _mapHandler.Map(internalReservation3, "Model.Reservation", "Airbnb.Reservation");


Console.ReadLine();