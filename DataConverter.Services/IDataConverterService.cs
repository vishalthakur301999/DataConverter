using System.Net.Http;
using System.Threading.Tasks;
using DataConverter.Domain.Entities;
using DataConverter.Request;
using DataConverter.Response;

namespace DataConverter.Services
{
    public interface IDataConverterService
    {
        Task<DataConverterResponse> ConvertData(DataConverterRequest dataConverterRequest);
        Flight PopulateFlight(DataConverterRequest dataConverterRequest);
    }
}