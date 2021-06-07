using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataConverter.Domain.Entities;
using DataConverter.Persistence;
using DataConverter.Request;
using DataConverter.Response;
using DataConverter.Services;
using DataConverter.UnitTests.Services.TestData;
using Microsoft.EntityFrameworkCore;
using FluentAssertions;
using Moq;
using Xunit;

namespace DataConverter.UnitTests.Services
{
    public class DataConverterServicesTests
    {
        [Fact]
        public void PopulateFlight_ShouldWork()
        {
            // Arrange
            Flight expected = new SampleFlight().ReturnSampleFlight();
            DataConverterService dataConverterService = new DataConverterService(null);

            // Act
            DataConverterRequest input = new SampleDataConverterRequest().ReturnSampleRequest();
            Flight actual = dataConverterService.PopulateFlight(input);

            // Assert
            Assert.Equal(expected.FlightNumber, actual.FlightNumber);
            Assert.Equal(expected.AirLine, actual.AirLine);
            Assert.Equal(expected.Fare, actual.Fare);
            Assert.Equal(expected.DeptTime, actual.DeptTime);
            Assert.Equal(expected.ArrivalTime, actual.ArrivalTime);

            Assert.Equal(expected.Source.AirportName, actual.Source.AirportName);
            Assert.Equal(expected.Source.AirportCity, actual.Source.AirportCity);
            Assert.Equal(expected.Source.AirportCountry, actual.Source.AirportCountry);
            Assert.Equal(expected.Source.IsInternational, actual.Source.IsInternational);

            Assert.Equal(expected.Destination.AirportName, actual.Destination.AirportName);
            Assert.Equal(expected.Destination.AirportCity, actual.Destination.AirportCity);
            Assert.Equal(expected.Destination.AirportCountry, actual.Destination.AirportCountry);
            Assert.Equal(expected.Destination.IsInternational, actual.Destination.IsInternational);

            Assert.Equal(expected.DesignatedAircraft.Manufacturer, actual.DesignatedAircraft.Manufacturer);
            Assert.Equal(expected.DesignatedAircraft.OwnerAirline, actual.DesignatedAircraft.OwnerAirline);
            Assert.Equal(expected.DesignatedAircraft.YearOfDelivery, actual.DesignatedAircraft.YearOfDelivery);
            Assert.Equal(expected.DesignatedAircraft.ModelName, actual.DesignatedAircraft.ModelName);
            Assert.Equal(expected.DesignatedAircraft.FirstClassSeats, actual.DesignatedAircraft.FirstClassSeats);
            Assert.Equal(expected.DesignatedAircraft.EconomyClassSeats, actual.DesignatedAircraft.EconomyClassSeats);
            Assert.Equal(expected.DesignatedAircraft.PremiumEconomyClassSeats,
                actual.DesignatedAircraft.PremiumEconomyClassSeats);
            Assert.Equal(expected.DesignatedAircraft.BusinessClassSeats, actual.DesignatedAircraft.BusinessClassSeats);

            Assert.Equal(expected.DesignatedPilot.Name, actual.DesignatedPilot.Name);
            Assert.Equal(expected.DesignatedPilot.HomeAddress, actual.DesignatedPilot.HomeAddress);
            Assert.Equal(expected.DesignatedPilot.PhoneNumber, actual.DesignatedPilot.PhoneNumber);
            Assert.Equal(expected.DesignatedPilot.AirLine, actual.DesignatedPilot.AirLine);

            Assert.Equal(expected.ProvidedAmenities.MealsProvided, actual.ProvidedAmenities.MealsProvided);
            Assert.Equal(expected.ProvidedAmenities.InFlightEntertainment,
                actual.ProvidedAmenities.InFlightEntertainment);
            Assert.Equal(expected.ProvidedAmenities.BaggageLimit, actual.ProvidedAmenities.BaggageLimit);
            Assert.Equal(expected.ProvidedAmenities.FlightChangeCharges, actual.ProvidedAmenities.FlightChangeCharges);
            Assert.Equal(expected.ProvidedAmenities.CancellationCharges, actual.ProvidedAmenities.CancellationCharges);
        }

        [Fact]
        public void ConvertData_ShouldWork()
        {
            // Arrange
            var mockSet = new Mock<DbSet<Flight>>();
            var mockContext = new Mock<IConverterContext>();
            mockContext.Setup(m => m.Flight).Returns(mockSet.Object);
            var service = new DataConverterService(mockContext.Object);
            
            // Act
            service.ConvertData(new SampleDataConverterRequest().ReturnSampleRequest());
            
            // Assert
            mockSet.Verify(m => m.Add(It.IsAny<Flight>()), Times.Once());
            mockContext.Verify(m => m.SaveChangesAsync(), Times.Once());
        }
       
        [Fact]
        public async void ConvertData_NullInput_ShouldWork(){
            // Arrange
            var mockContext = new Mock<IConverterContext>();
            DataConverterService dataConverterService = new DataConverterService(mockContext.Object);
            DataConverterResponse expected = new DataConverterResponse();
            expected.statusCode = DataConverterResponse.StatusCode.BadRequest;
            expected.FlightId = null;
            
            // Act
            var actual = await dataConverterService.ConvertData(null);
            
            // Assert
            actual.Should().BeEquivalentTo(expected);
        }
        [Fact]
        public async void ConvertData_TryCatch_ShouldWork()
        {
            var expected = new DataConverterResponse
            {
                statusCode = DataConverterResponse.StatusCode.InternalServerError
            };
            var mockContext = new Mock<IConverterContext>();
            mockContext.Setup(c => c.SaveChangesAsync());

            var service = new DataConverterService(mockContext.Object);
            var actual = await service.ConvertData(new SampleDataConverterRequest().ReturnSampleRequest());
            
            Assert.Equal(expected.statusCode, actual.statusCode);
        }
        
        [Fact]
        public async void ConvertData_ResponseGen_ShouldWork()
        {
            var data = new List<Flight>().AsQueryable();

            var mockSet = new Mock<DbSet<Flight>>();
            mockSet.As<IQueryable<Flight>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<Flight>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<Flight>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<Flight>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());
            var expected = new DataConverterResponse
            {
                statusCode = DataConverterResponse.StatusCode.Ok
            };
            var mockContext = new Mock<IConverterContext>();
            mockContext.Setup(c => c.Flight).Returns(mockSet.Object);
            mockContext.Setup(c => c.SaveChangesAsync()).Returns(() => Task.Run(() => 1));

            var service = new DataConverterService(mockContext.Object);
            var actual = await service.ConvertData(new SampleDataConverterRequest().ReturnSampleRequest());
            Assert.Equal(expected.statusCode, actual.statusCode);
        }
        
    }
}

