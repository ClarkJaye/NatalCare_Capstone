using NatalCare.Models.Entities;
using static NatalCare.DataAccess.Response.ServiceResponses;

namespace NatalCare.DataAccess.Interfaces
{
    public interface INewbornServices
    {
        Task<GeneralResponse> GetNewborns();
        Task<GeneralResponse> GetInformation(string id);
        Task<CommonResponse> Create(Newborn newborn, string userId);
        Task<GeneralResponse> Edit(string id, string userId);



        //ViewBag
        Task<(int todayCount, int monthCount, int yearCount)> GetNewbornCountsAsync();
    }
}
