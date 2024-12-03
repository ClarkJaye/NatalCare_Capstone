using NatalCare.Models.Entities;
using System.Collections.Generic;

namespace NatalCare.Models.ViewModel.Patient
{
    public class OPDVM
    {
        public OpdVisit? OPDVisit { get; set; }            
        public Prenatal? PrenatalRecord { get; set; }       
        public List<Prenatal>? PrenatalRecords { get; set; }
        public NewbornHearing? HearingRecord { get; set; }
        public List<NewbornHearing>? HearingRecords { get; set; }
        public NewbornScreening? ScreeningRecord { get; set; }
        public List<NewbornScreening>? ScreeningRecords { get; set; }

    }
}
