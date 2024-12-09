using NatalCare.Models.Entities;

namespace NatalCare.Models.ViewModel.Patient
{
    public class PrenatalVM
    {
        public Prenatal? Prenatal { get; set; }
        public List<PrenatalVisit>? PrenatalVisit { get; set; }
    }
}
