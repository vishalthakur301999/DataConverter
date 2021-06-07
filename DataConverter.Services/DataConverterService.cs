using System;
using System.Threading.Tasks;
using DataConverter.Domain.Entities;
using DataConverter.Persistence;
using DataConverter.Request;
using DataConverter.Response;

namespace DataConverter.Services
{
    public class DataConverterService: IDataConverterService
    {
        private readonly IConverterContext _converterContext;

        public DataConverterService(IConverterContext converterContext)
        {
            _converterContext = converterContext;
        }

        public async Task<DataConverterResponse> ConvertData(DataConverterRequest dataConverterRequest)
        {
            DataConverterResponse dataConverterResponse = new DataConverterResponse();
            if (dataConverterRequest == null)
            {
                dataConverterResponse.FlightId = null;
                dataConverterResponse.statusCode = DataConverterResponse.StatusCode.BadRequest;
            }
            else
            {
                try
                {
                    Flight flight = PopulateFlight(dataConverterRequest);
                    _converterContext.Flight.Add(flight);
                    var result = await _converterContext.SaveChangesAsync();
                    if (result > 0)
                    {
                        dataConverterResponse.FlightId = flight.FLightId;
                        dataConverterResponse.statusCode = DataConverterResponse.StatusCode.Ok;
                    }
                }
                catch
                {
                    dataConverterResponse.FlightId = null;
                    dataConverterResponse.statusCode = DataConverterResponse.StatusCode.InternalServerError;
                }
            }
            return dataConverterResponse;
        }

        public Flight PopulateFlight(DataConverterRequest dataConverterRequest)
        {
            Flight flight = new Flight
            {
                FLightId = new Guid(),
                FlightNumber = dataConverterRequest.FlightNumber,
                AirLine = dataConverterRequest.AirLine,
                ArrivalTime = dataConverterRequest.ArrivalTime,
                DeptTime = dataConverterRequest.DeptTime,
                Fare =  dataConverterRequest.Fare,
                DesignatedAircraft = new Aircraft
                {
                    AircraftId = new Guid(),
                    Manufacturer = dataConverterRequest.AircraftManufacturer,
                    YearOfDelivery = dataConverterRequest.AirCraftYearOfDelivery,
                    OwnerAirline = dataConverterRequest.AirLine,
                    ModelName = dataConverterRequest.AirCraftModelName,
                    BusinessClassSeats = dataConverterRequest.BusinessClassSeats,
                    PremiumEconomyClassSeats = dataConverterRequest.PremiumEconomyClassSeats,
                    EconomyClassSeats = dataConverterRequest.EconomyClassSeats,
                    FirstClassSeats = dataConverterRequest.FirstClassSeats,
                },
                DesignatedPilot = new Pilot
                {
                    PilotId = new Guid(),
                    Name = dataConverterRequest.PilotName,
                    HomeAddress = dataConverterRequest.PilotHomeAddress,
                    PhoneNumber = dataConverterRequest.PilotPhoneNumber,
                    AirLine = dataConverterRequest.AirLine
                },
                Source = new Airport
                {
                    AirportCode = new Guid(),
                    AirportCity = dataConverterRequest.SourceAirportCity,
                    AirportCountry = dataConverterRequest.SourceAirportCountry,
                    AirportName = dataConverterRequest.SourceAirportName,
                    IsInternational = dataConverterRequest.SourceIsInternational
                },
                Destination = new Airport
                {
                    AirportCode = new Guid(),
                    AirportCity = dataConverterRequest.DestAirportCity,
                    AirportCountry = dataConverterRequest.DestAirportCountry,
                    AirportName = dataConverterRequest.DestAirportName,
                    IsInternational = dataConverterRequest.DestIsInternational
                },
                ProvidedAmenities = new Amenities
                {
                    AmenitiesId = new Guid(),
                    BaggageLimit = dataConverterRequest.BaggageLimit,
                    CancellationCharges = dataConverterRequest.CancellationCharges,
                    FlightChangeCharges = dataConverterRequest.FlightChangeCharges,
                    InFlightEntertainment = dataConverterRequest.InFlightEntertainment,
                    MealsProvided = dataConverterRequest.MealsProvided
                }
            };
            flight.DesignatedAircraftId = flight.DesignatedAircraft.AircraftId;
            flight.DesignatedPilotId = flight.DesignatedPilot.PilotId;
            flight.SourceCode = flight.Source.AirportCode;
            flight.DestinationCode = flight.Destination.AirportCode;
            flight.ProvidedAmenitiesId = flight.ProvidedAmenities.AmenitiesId;
            return flight;
        }
    }
}