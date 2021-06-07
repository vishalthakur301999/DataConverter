using System;
using DataConverter.Domain.Entities;

namespace DataConverter.UnitTests.Services.TestData
{
    public class SampleFlight
    {
        public Flight ReturnSampleFlight()
        {
            Flight flight = new Flight();
            flight.FLightId = new Guid("af6426b6-4874-42f3-b892-38d7363eb8c6");
            flight.FlightNumber = "6E-999";
            flight.AirLine= "Indigo";
            flight.Fare= 5000;
            flight.DeptTime= "20=00";
            flight.ArrivalTime= "23=00";
            
            flight.Source = new Airport();
            flight.Source.AirportCode = new Guid();
            flight.Source.AirportName= "Indira Gandhi International Airport";
            flight.Source.AirportCity= "Delhi";
            flight.Source.AirportCountry= "India";
            flight.Source.IsInternational= true;
            
            flight.Destination = new Airport();
            flight.Destination.AirportCode = new Guid();
            flight.Destination.AirportName= "Chennai International Airport";
            flight.Destination.AirportCity= "Chennai";
            flight.Destination.AirportCountry= "India";
            flight.Destination.IsInternational= true;
            
            flight.DesignatedAircraft = new Aircraft();
            flight.DesignatedAircraft.AircraftId = new Guid();
            flight.DesignatedAircraft.OwnerAirline = "Indigo";
            flight.DesignatedAircraft.Manufacturer= "Airbus";
            flight.DesignatedAircraft.YearOfDelivery= "2011";
            flight.DesignatedAircraft.ModelName= "A320 neo";
            flight.DesignatedAircraft.FirstClassSeats= 0;
            flight.DesignatedAircraft.BusinessClassSeats= 0;
            flight.DesignatedAircraft.PremiumEconomyClassSeats= 0;
            flight.DesignatedAircraft.EconomyClassSeats= 180;
            
            flight.DesignatedPilot = new Pilot();
            flight.DesignatedPilot.PilotId = new Guid();
            flight.DesignatedPilot.Name= "Vishal Thakur";
            flight.DesignatedPilot.PhoneNumber= "9988998899";
            flight.DesignatedPilot.HomeAddress= "Rohini; Delhi";
            flight.DesignatedPilot.AirLine = "Indigo";
            
            flight.ProvidedAmenities = new Amenities();
            flight.ProvidedAmenities.AmenitiesId = new Guid();
            flight.ProvidedAmenities.MealsProvided= false;
            flight.ProvidedAmenities.InFlightEntertainment= false;
            flight.ProvidedAmenities.BaggageLimit= 15;
            flight.ProvidedAmenities.CancellationCharges= 4000;
            flight.ProvidedAmenities.FlightChangeCharges = 3000;
            
            flight.SourceCode = flight.Source.AirportCode;
            flight.DestinationCode = flight.Destination.AirportCode;
            flight.DesignatedAircraftId = flight.DesignatedAircraft.AircraftId;
            flight.DesignatedPilotId = flight.DesignatedPilot.PilotId;
            flight.ProvidedAmenitiesId = flight.ProvidedAmenities.AmenitiesId;
            return flight;
        }
    }
}
