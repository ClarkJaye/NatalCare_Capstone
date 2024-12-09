using NatalCare.Models.Entities;
using static NatalCare.DataAccess.Response.ServiceResponses;

namespace NatalCare.DataAccess.Interfaces
{
    public interface INewbornServices
    {
        Task<List<Newborn>> GetNewborns();
        Task<List<Newborn>> GetDeletedNewborns();
        Task<GeneralResponse> GetInformation(string id);
        Task<Newborn> GetGeneralInformation(string id);
        Task<CommonResponse> Create(Newborn newborn, string userId);
        Task<GeneralResponse> Edit(string id, string userId);
        Task<GeneralResponse> Update(Newborn newborn, string userId);
        Task<CommonResponse> Delete(string id, string userId);
        Task<CommonResponse> RetrievedAync(string id, string userId);

        //ViewBag
        Task<(int todayCount, int monthCount, int yearCount)> GetNewbornCountsAsync();
    }
}
