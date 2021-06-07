using System;

namespace DataConverter.Request
{
    public partial class DataConverterRequest
    {
        public string FlightNumber { get; set; } 
        public string AirLine { get; set;  } 
        public double Fare { get; set; } 
        public string DeptTime { get; set; } 
        public string ArrivalTime { get; set; } 
        public string SourceAirportName { get; set; } 
        public string SourceAirportCity { get; set; } 
        public string SourceAirportCountry { get; set; } 
        public Boolean SourceIsInternational { get; set; }
        public string DestAirportName { get; set; } 
        public string DestAirportCity { get; set; } 
        public string DestAirportCountry { get; set; } 
        public Boolean DestIsInternational { get; set; } 
        public string AircraftManufacturer { get; set; }
        public string AirCraftYearOfDelivery { get; set; }
        public string AirCraftModelName { get; set; }
        public int FirstClassSeats { get; set; }
        public int BusinessClassSeats { get; set; }
        public int PremiumEconomyClassSeats { get; set; }
        public int EconomyClassSeats { get; set; }
        public string PilotName { get; set; }
        public string PilotPhoneNumber { get; set; }
        public string PilotHomeAddress { get; set; }
        public Boolean MealsProvided { get; set; }
        public Boolean InFlightEntertainment { get; set; }
        public int BaggageLimit { get; set; }
        public double CancellationCharges { get; set; }
        public double FlightChangeCharges { get; set; }
    }
}