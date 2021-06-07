using System;

namespace DataConverter.Response
{
    public partial class DataConverterResponse
    {
        public Guid? FlightId { get; set; }
        public StatusCode statusCode { get; set; }

        public enum StatusCode
        {
            Ok = 200,
            InternalServerError = 500,
            BadRequest = 400,
            NotFound = 404,
            Created = 201,
        }
    }
}