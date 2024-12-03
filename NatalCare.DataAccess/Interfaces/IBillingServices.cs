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

        Task<CommonResponse> createServices(string itemName, string description, decimal price);

        Task<SearchResultResponse> searchPatient(string patientName);

        Task<List<Items>> allItems();

        Task<List<Servicesss>> allServices();

        Task<PrintInvoiceResponse> createInvoice(BillingDTO billingDTO);

        Task<InvoiceListDTO> GetPayments();

        Task<PrintDTO> PaymentVM(int? invoiceNumber);

        Task<BillingAndPrintVM> generateInvoiceModel(int? id);

        Task<CommonResponse> deleyePayment(int paymentId);


    }
}
