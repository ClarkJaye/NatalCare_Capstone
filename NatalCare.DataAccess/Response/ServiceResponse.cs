using NatalCare.Models.Entities;

namespace NatalCare.DataAccess.Response
{
    public class ServiceResponses
    {
        public record class CommonResponse(bool IsSuccess, string Message);
        public record class GeneralResponse(bool IsSuccess, object? Item, string Message);

        public record class SearchResultResponse(bool IsSuccess, List<Patients> list);


    }
}
