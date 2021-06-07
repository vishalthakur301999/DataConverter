using DataConverter.Request;

namespace DataConverter.UnitTests.Services.TestData
{
    public class SampleDataConverterRequest
    {
        public DataConverterRequest ReturnSampleRequest()
        {
            DataConverterRequest dataConverterRequest = new DataConverterRequest();
            dataConverterRequest.FlightNumber = "6E-999";
            dataConverterRequest.AirLine= "Indigo";
            dataConverterRequest.Fare= 5000;
            dataConverterRequest.DeptTime= "20=00";
            dataConverterRequest.ArrivalTime= "23=00";
            dataConverterRequest.SourceAirportName= "Indira Gandhi International Airport";
            dataConverterRequest.SourceAirportCity= "Delhi";
            dataConverterRequest.SourceAirportCountry= "India";
            dataConverterRequest.SourceIsInternational= true;
            dataConverterRequest.DestAirportName= "Chennai International Airport";
            dataConverterRequest.DestAirportCity= "Chennai";
            dataConverterRequest.DestAirportCountry= "India";
            dataConverterRequest.DestIsInternational= true;
            dataConverterRequest.AircraftManufacturer= "Airbus";
            dataConverterRequest.AirCraftYearOfDelivery= "2011";
            dataConverterRequest.AirCraftModelName= "A320 neo";
            dataConverterRequest.FirstClassSeats= 0;
            dataConverterRequest.BusinessClassSeats= 0;
            dataConverterRequest.PremiumEconomyClassSeats= 0;
            dataConverterRequest.EconomyClassSeats= 180;
            dataConverterRequest.PilotName= "Vishal Thakur";
            dataConverterRequest.PilotPhoneNumber= "9988998899";
            dataConverterRequest.PilotHomeAddress= "Rohini; Delhi";
            dataConverterRequest.MealsProvided= false;
            dataConverterRequest.InFlightEntertainment= false;
            dataConverterRequest.BaggageLimit= 15;
            dataConverterRequest.CancellationCharges= 4000;
            dataConverterRequest.FlightChangeCharges = 3000;
            return dataConverterRequest;
        }
    }
}