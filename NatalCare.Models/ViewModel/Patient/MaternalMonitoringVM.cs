using NatalCare.Models.Entities;

namespace NatalCare.Models.ViewModel.Patient
{
    public class MaternalMonitoringVM
    {
        public MaternalMonitoring? MaternalMonitoring { get; set; }
        public List<ProgressLabor>? ProgressLabor { get; set; }
    
    }
}
