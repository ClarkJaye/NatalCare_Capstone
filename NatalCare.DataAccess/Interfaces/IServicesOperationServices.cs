﻿using NatalCare.Models.Entities;
using static NatalCare.DataAccess.Response.ServiceResponses;

namespace NatalCare.DataAccess.Interfaces
{
    public interface IServicesOperationServices
    {
        //------ PRENATAL ------//
        Task<GeneralResponse> GetPrenatalFormRecordAsync(string id);
        Task<Prenatal> GetPrenatalRecord(string id, string caseno);
        Task<List<Prenatal>> GetDeletedPrenatalRecords(string patientId);
        Task<List<Prenatal>> GetPrenatalRecords(string patientId);
        //CRUD
        Task<CommonResponse> AddPrenatalRecordAsync(Prenatal prenatal, string patientId, string userId);
        Task<CommonResponse> DeletePrenatalRecordAsync(string caseNo, string userId);
        Task<GeneralResponse> GetPrenatalRecordAsync(string caseNo);
        Task<Prenatal> GetPrenatalInformation(string caseNo);
        Task<CommonResponse> UpdatePrenatalRecordAsync(Prenatal prenatal, string userId);

        //------ PRENATAL VISIT ------//
        Task<List<PrenatalVisit>> GetPrenatalVisitsRecords(string caseNo, string patientId);
        //CRUD
        Task<CommonResponse> AddPrenatalVisitRecordAsync(PrenatalVisit prenatalvisit, string patientId, string caseNo, string userId);
        Task<GeneralResponse> GetPrenatalVisitRecordAsync(string caseNo);
        Task<CommonResponse> UpdatePrenatalVisitRecordAsync(PrenatalVisit prenatal, string userId);
        Task<CommonResponse> DeletePrenatalVisitRecordAsync(string caseNo, string userId);
        Task<CommonResponse> RetrievedPrenetalAync(string caseno, string userId);

        //------ FAMILY PLANNING ------//
        Task<List<FamilyPlanning>> GetFamilyPlanningRecords(string patientId);
        Task<List<FamilyPlanning>> GetDeletedFPRecords(string patientId);
        //CRUD
        Task<CommonResponse> AddFPRecordAsync(FamilyPlanning fp, string patientId, string userId);
        Task<GeneralResponse> GetFPRecordAsync(string caseNo);
        Task<CommonResponse> UpdateFPRecordAsync(FamilyPlanning fp, string userId);
        Task<CommonResponse> DeleteFPRecordAsync(string caseNo, string userId);
        Task<CommonResponse> RetrievedFPAync(string caseno, string userId);

        //------ NEWBORN HEARING ------// 
        Task<List<NewbornHearing>> GetDeletedHRRecords(string patientId);
        Task<CommonResponse> RetrievedHRAync(string caseno, string userId);
        Task<List<NewbornHearing>> GetHearingRecords(string patientId);
        Task<GeneralResponse> Get_Newborn(string motherId);
        Task<CommonResponse> AddHRRecordAsync(NewbornHearing item, string patientId, string userId);
        Task<GeneralResponse> GetHRRecordAsync(string caseNo);
        Task<CommonResponse> UpdateHRRecordAsync(NewbornHearing item, string userId);
        Task<CommonResponse> DeleteHRRecordAsync(string caseNo, string userId);

        //------ NEWBORN SCREENING ------// 
        Task<List<NewbornScreening>> GetDeletedSNRecords(string patientId);
        Task<CommonResponse> RetrievedSNAync(string caseno, string userId);
        Task<List<NewbornScreening>> GetScreeningRecords(string patientId);
        Task<CommonResponse> AddSNRecorddAsync(NewbornScreening item, string patientId, string userId);
        Task<GeneralResponse> GetScreeningRecordAsync(string caseNo);
        Task<CommonResponse> DeleteScreeningRecordAsync(string caseNo, string userId);
        Task<CommonResponse> UpdateScreeningRecordAsync(NewbornScreening item, string userId);


        //------ DELIVERY ------// 
        Task<List<Delivery>> GetDeletedDeliveryRecords(string patientId);
        Task<List<Delivery>> GetDeliveryRecords(string patientId);
        Task<Delivery> GetDeliveryRecord(string patientId, string caseno);
        //CRUD
        Task<CommonResponse> AddDeliveryRecordAsync(Delivery delivery, string patientId, string userId);
        Task<CommonResponse> DeleteDeliveryRecordAsync(string caseNo, string userId);
        Task<GeneralResponse> GetDeliveryRecordAsync(string caseNo);
        Task<CommonResponse> UpdateDeliveryRecordAsync(Delivery delivery, string userId);
        Task<CommonResponse> RetrievedDeliveryAync(string caseno, string userId);


        //PHYSICAL EXAMINATION
        Task<PhysicalExamination> GetPhysicalExaminationRecords(string patientId, string deliveryId);

        //OBSTETRICAL
        Task<Obstetrical> GetObstetricalRecords(string patientId, string deliveryId);

        //MATERNAL MONITORING
        //Task<Obstetrical> GetMaternalMonitoringRecords(string patientId, string deliveryId);

        //CLINICAL SHEET
        Task<ClinicalFaceSheet> GetClinicalSheetRecords(string patientId, string deliveryId);

        //DISCHARGEMENT FORM
        Task<DischargementForm> GetDischargementRecords(string patientId, string deliveryId);

        


        //ADMISSION
        Task<Delivery> GetAdmittedDeliveryRecord(string caseno);
        Task<CommonResponse> AddAdmissionDelivery(Delivery data, string userId);
        Task<CommonResponse> UpdateAdmissionDelivery(Delivery data, string userId);
        Task<List<Delivery>> GetAllDeliveryRecords();


        //OPD 
        Task<List<OpdVisit>> GetAllOPDRecords();
        Task<OpdVisit> GetOPDRecord(int id);
        Task<GeneralResponse> GetOPDDataRecord(int id);

    }
}
