namespace NatalCare.DataAccess.Response
{
    public class ServiceResponses
    {
        public record class CommonResponse(bool IsSuccess, string Message);
        public record class GeneralResponse(bool IsSuccess, object? Obj, string Message);
    }
}
