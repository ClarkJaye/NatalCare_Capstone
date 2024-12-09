using NatalCare.Models.DTOs;
using NatalCare.Models.DTOs.VM;
using NatalCare.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static NatalCare.DataAccess.Response.ServiceResponses;

namespace NatalCare.DataAccess.Interfaces
{
    public interface IBillingServices
    {
        Task<CommonResponse> createItems(string itemName, string description, decimal price);

        Task<CommonResponse> editItems(int id, string itemName, string description, decimal price);

        Task<CommonResponse> createServices(string itemName, string description, decimal price);

        Task<CommonResponse> editServices(int id, string serviceName, string description, decimal price);


        Task<SearchResultResponse> searchPatient(string patientName);

        Task<List<Items>> allItems();

        Task<List<Servicesss>> allServices();

        Task<PrintInvoiceResponse> createInvoice(BillingDTO billingDTO);

        Task<InvoiceListDTO> GetPayments();

        Task<List<PatientPayments>> GetPatientPaymentHistory(int paymentId);

        Task<PrintDTO> PaymentVM(int? invoiceNumber);

        Task<BillingAndPrintVM> generateInvoiceModel(int? id);

        Task<CommonResponse> deleyePayment(int paymentId);

        Task<CommonResponse> deleteItem(int itemId);

        Task<CommonResponse> deleteService(int serviceId);


        Task<CommonResponse> deletePatientPayment(int? paymentId);

        Task<PatientPayments> payInvoice();

        Task<CommonResponse> addPatientPayment(PatientPayments? patientPayments);

        Task<string> patientID(int? id);

        Task<CommonResponse> editPatientPayment(PatientPayments? patientPayments);

        Task<PrintInvoiceResponse> editInvoice(BillingDTO billingDTO);

        Task<dynamic> GetDataByYearAndMonth(int? year, string? month);

        Task<dynamic> GetPaymentStatusStatistics();

        
    }
}
