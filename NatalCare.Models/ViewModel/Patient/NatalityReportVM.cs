namespace NatalCare.Models.ViewModel.Patient
{
    public class NatalityReportVM
    {
        // Counts for newborns categorized by age group and gender
        public int Male_10_14 { get; set; }
        public int Female_10_14 { get; set; }
        public int Male_15_19 { get; set; }
        public int Female_15_19 { get; set; }
        public int Male_20_49 { get; set; }
        public int Female_20_49 { get; set; }

        // Total live births
        public int TotalLiveBirths { get; set; }

        // Vaginal deliveries
        public int VaginalDeliveries { get; set; }
        public int VaginalMale_10_14 { get; set; }
        public int VaginalFemale_10_14 { get; set; }
        public int VaginalMale_15_19 { get; set; }
        public int VaginalFemale_15_19 { get; set; }
        public int VaginalMale_20_49 { get; set; }
        public int VaginalFemale_20_49 { get; set; }

        //CS deliveries
        public int CSDeliveries { get; set; }
        public int CSMale_10_14 { get; set; }
        public int CSFemale_10_14 { get; set; }
        public int CSMale_15_19 { get; set; }
        public int CSFemale_15_19 { get; set; }
        public int CSMale_20_49 { get; set; }
        public int CSFemale_20_49 { get; set; }

        // Attended by different professionals
        public int AttendedByPhysicians { get; set; }
        public int PSDeliveries { get; set; }
        public int PSMale_10_14 { get; set; }
        public int PSFemale_10_14 { get; set; }
        public int PSMale_15_19 { get; set; }
        public int PSFemale_15_19 { get; set; }
        public int PSMale_20_49 { get; set; }
        public int PSFemale_20_49 { get; set; }

        public int AttendedByMidwives { get; set; }
        public int MWDeliveries { get; set; }
        public int MWMale_10_14 { get; set; }
        public int MWFemale_10_14 { get; set; }
        public int MWMale_15_19 { get; set; }
        public int MWFemale_15_19 { get; set; }
        public int MWMale_20_49 { get; set; }
        public int MWFemale_20_49 { get; set; }

        public int AttendedByNurses { get; set; }
        public int NurseDeliveries { get; set; }
        public int NurseMale_10_14 { get; set; }
        public int NurseFemale_10_14 { get; set; }
        public int NurseMale_15_19 { get; set; }
        public int NurseFemale_15_19 { get; set; }
        public int NurseMale_20_49 { get; set; }
        public int NurseFemale_20_49 { get; set; }

        // Age categories of mothers (female patients) based on age
        public int FemaleMothersUnder20 { get; set; }
        public int FemaleMothers20To49 { get; set; }
        public int FemaleMothersOver49 { get; set; }

    }


}
