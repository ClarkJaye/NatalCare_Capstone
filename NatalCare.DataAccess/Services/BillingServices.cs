using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using NatalCare.DataAccess.Interfaces;
using NatalCare.DataAccess.Repository.IRepository;
using NatalCare.Models.DTOs;
using NatalCare.Models.Entities;
using System.Security.Claims;
using static NatalCare.DataAccess.Response.ServiceResponses;


namespace NatalCare.DataAccess.Services
{
    public class BillingServices : IBillingServices
    {

        private readonly IAppUnitOfWork _unitOfWork;

        private readonly UserManager<User> _userManager;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public BillingServices(IAppUnitOfWork unitOfWork, UserManager<User> userManager, IHttpContextAccessor httpContextAccessor)
        {
            _unitOfWork = unitOfWork;
            _userManager = userManager;
            _httpContextAccessor = httpContextAccessor;
        }

        public Task<List<Items>> allItems()
        {
            var allItems = _unitOfWork.Repository<Items>().AsQueryable().OrderBy(a => a.ItemID).ToListAsync();

            return allItems;
        }

        public Task<List<Servicesss>> allServices()
        {
            var allServices = _unitOfWork.Repository<Servicesss>().AsQueryable().OrderBy(a => a.ServiceID).ToListAsync();

            return allServices;
        }

        public async Task<CommonResponse> createInvoice(BillingDTO billingDTO)
        {

            var userId = _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);

            var user = await _userManager.Users.FirstOrDefaultAsync(a => a.Id == userId);

            var patient = await _unitOfWork.Repository<Patients>().AsQueryable().FirstOrDefaultAsync(a => a.PatientID == billingDTO.PatientName);

            if (patient == null)
            {
                return new CommonResponse(false, "Patient Not Found");
            }

            Payments payment = new Payments
            {
                PatientID = patient.PatientID,
                Total_Amount = billingDTO.SubTotal,
                Final_Amount = billingDTO.TotalAmount,
                Payment_Status = "PENDING",
                Discount = billingDTO.Discount,
                PhilHealth_Deduction = billingDTO.PhilHeathTotal,
                Notes = billingDTO.Notes,
                Created_At = DateTime.Now,
                PatientCreatedBy = user.Id,
                Updated_At = null,
                PatientUpdatedBy = null
            };

            _unitOfWork.Repository<Payments>().Add(payment);
            await _unitOfWork.Complete();

            foreach (var items in billingDTO.Items)
            {
                var ogItem = await _unitOfWork.Repository<Items>().AsQueryable().FirstOrDefaultAsync(a => a.ItemName == items.ItemName);

                ItemPayments item = new ItemPayments 
                {
                    PaymentID = payment.PaymentID, 
                    ItemID = ogItem.ItemID, 
                    Quantity = items.Quantity,
                    PhilHealthCovered = items.PhilHealthCovered 
                };

                _unitOfWork.Repository<ItemPayments>().Add(item);
       

            }
            await _unitOfWork.Complete();


            foreach (var services in billingDTO.Services)
            {
                var ogService = _unitOfWork.Repository<Servicesss>().AsQueryable().Where(a => a.ServiceName == services.ServiceName).FirstOrDefault();

                ServicesPayment service = new ServicesPayment
                {
                    PaymentID = payment.PaymentID,
                    ServiceID = ogService.ServiceID,
                    Quantity = services.Quantity,
                    PhilhealthCovered = services.PhilHealthCovered
                };

                _unitOfWork.Repository<ServicesPayment>().Add(service);


            }
            await _unitOfWork.Complete();


            return new CommonResponse(true, "Patient Not");

        }






        public async Task<CommonResponse> createItems(string itemName, string description, decimal price)
        {

            var item = new Items{
                ItemName = itemName,
                Description = description,
                Price = price
            };

            _unitOfWork.Repository<Items>().Add(item);
            await _unitOfWork.Complete();

            return new CommonResponse(true, "Item Added Successfully");
        }

        public async Task<CommonResponse> createServices(string serviceName, string description, decimal price)
        {
            var services = new Servicesss
            {
                ServiceName = serviceName,
                Description = description,
                Price = price
            };

            _unitOfWork.Repository<Servicesss>().Add(services);
            await _unitOfWork.Complete();

            return new CommonResponse(true, "Service Added Successfully");
        }

        public async Task<SearchResultResponse> searchPatient(string patientName)
        {
            var nameToLower = patientName.ToLower();

            var matchingPatients = await _unitOfWork.Repository<Patients>()
                .AsQueryable()
                .Where(a => a.FirstName.ToLower().Contains(nameToLower) ||
                            a.MiddleName.ToLower().Contains(nameToLower) ||
                            a.LastName.ToLower().Contains(nameToLower))
                .Take(10)
                .ToListAsync();

            return new SearchResultResponse(true, matchingPatients);
        }

    }
}
