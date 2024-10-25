using NatalCare.Models.Entities;

namespace NatalCare.DataAccess.Interfaces
{
    public interface INewbornServices
    {
        Task<bool> Create(Newborn newborn, string userId);

        
        ////ViewBag
        //Task<int> GetTodayNewbornCount();
        //Task<int> GetMonthlyNewbornCount();
        //Task<int> GetYearlyNewbornCount();



    }
}
