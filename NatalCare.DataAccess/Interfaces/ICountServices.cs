
namespace NatalCare.DataAccess.Interfaces
{
    public interface ICountServices
    {
        Task<(int totalAdmitted, int totalInLabor, int totalPospartum)> GetAdmissionCountsAsync();

        Task<(int totalCount, int todayCount)> GetOPDCountsAsync();
    }
}
