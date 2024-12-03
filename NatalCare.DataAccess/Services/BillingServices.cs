using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using NatalCare.DataAccess.data;
using NatalCare.DataAccess.Interfaces;
using NatalCare.DataAccess.Repository.IRepository;
using NatalCare.Models.DTOs;
using NatalCare.Models.DTOs.VM;
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
        private readonly AppDbContext db;

        public BillingServices(IAppUnitOfWork unitOfWork, UserManager<User> userManager, IHttpContextAccessor httpContextAccessor, AppDbContext db)
        {
            _unitOfWork = unitOfWork;
            _userManager = userManager;
            _httpContextAccessor = httpContextAccessor;
            this.db = db;   
        }

        public async Task<InvoiceListDTO> GetPayments()
        {

            var payments = await _unitOfWork.Repository<Payments>().AsQueryable().Include(a => a.Patient).Include(a => a.Staff).Include(a => a.CreatedBy).ToListAsync();

            var patientPayments = await _unitOfWork.Repository<PatientPayments>().AsQueryable().Include(a => a.Patients).Include(a => a.Payments).ToListAsync();

            return new InvoiceListDTO
            {
                Payments = payments,
                PatientPayments = patientPayments
            };
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

        public async Task<PrintInvoiceResponse> createInvoice(BillingDTO billingDTO)
        {

            var userId = _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);

            var user = await _userManager.Users.FirstOrDefaultAsync(a => a.Id == userId);

            var patient = await _unitOfWork.Repository<Patients>().AsQueryable().FirstOrDefaultAsync(a => a.PatientID == billingDTO.PatientName);

            if (patient == null)
            {
                return new PrintInvoiceResponse(false, 0);
            }

            //var staff = await _unitOfWork.Repository<Staff>().AsQueryable().FirstOrDefaultAsync(a => a.Na == billingDTO.StaffName);

            Payments payment = new Payments
            {
                PatientID = patient.PatientID,
                Total_Amount = billingDTO.SubTotal,
                Final_Amount = billingDTO.TotalAmount,
                Payment_Status = "PENDING",
                Discount = billingDTO.Discount,
                PhilHealth_Deduction = billingDTO.PhilHeathTotal,
                Notes = billingDTO.Notes,
                BillDate = billingDTO.BillDate,
                DueDate = billingDTO.DueDate,
                Created_At = DateTime.Now,
                PatientCreatedBy = user.Id,
                Updated_At = null,
                PatientUpdatedBy = null,
                StaffID = int.Parse(billingDTO.StaffName)
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


            return new PrintInvoiceResponse(true, payment.PaymentID);

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

        //public async Task<PrintVM> PaymentVM(int? invoiceNumber)
        //{

        //    try
        //    {
        //        //var payment =  _unitOfWork.Repository<Payments>().AsQueryable().FirstOrDefault(a => a.PaymentID == invoiceNumber);
        //        var payment =  db.Payments.FirstOrDefault(a => a.PaymentID == invoiceNumber);




        //        var patientPayment = db.PatientPayments.Where(a => a.PaymentID == invoiceNumber).ToList();


        //        //var itemPayments =  _unitOfWork.Repository<ItemPayments>().AsQueryable().Where(a => a.PaymentID == payment.PaymentID).ToList();

        //        //var servicePayments =  _unitOfWork.Repository<ServicesPayment>().AsQueryable().Where(a => a.PaymentID == payment.PaymentID).ToList();

        //        //var patientPayment =  _unitOfWork.Repository<PatientPayments>().AsQueryable().Where(a => a.PaymentID == payment.PaymentID).ToList();

        //        //var patient =  _unitOfWork.Repository<Patients>().AsQueryable().FirstOrDefault(a => a.PatientID == payment.PatientID);


        //        var createdByUser = await _userManager.Users
        //            .FirstOrDefaultAsync(a => a.Id == payment.PatientCreatedBy);


        //        var paymentID = payment.PaymentID;

        //        //PATIENT PAYMENT
        //        decimal? balance = 0;

        //        List<decimal?> amountPaid = new List<decimal?>();

        //        if (patientPayment.Count > 0)
        //        {
        //            patientPayment.ForEach(paymentDetail =>
        //            {
        //                amountPaid.Add(paymentDetail.Amount);
        //            });
        //            decimal totalPaid = amountPaid.Sum(x => x ?? 0);
        //            balance -= totalPaid;
        //            paymentID = payment.PaymentID;
        //        }
        //        else
        //        {
        //            balance = payment.Final_Amount;
        //            paymentID = payment.PaymentID;
        //        }



        //        // ITEMS
        //        var itemPayments = db.ItemPayments.Where(a => a.PaymentID == invoiceNumber).ToList();

        //        List<ItemsVM> itemsList = new List<ItemsVM>();

        //        if (itemPayments.Count > 0)
        //        {
        //            foreach (var item in itemPayments)
        //            {
        //                var ogItem = db.Items.AsNoTracking().FirstOrDefault(a => a.ItemID == item.ItemID);

        //                if (ogItem == null)
        //                {
        //                    throw new Exception($"Item with ID {item.ItemID} not found.");
        //                }

        //                itemsList.Add(new ItemsVM
        //                {
        //                    ItemName = ogItem.ItemName,
        //                    Quantity = item.Quantity,
        //                    Price = ogItem.Price,
        //                    PhilHealthCovered = item.PhilHealthCovered,
        //                    Total = (ogItem.Price * item.Quantity) - item.PhilHealthCovered
        //                });

        //            }
        //        }
        //        else
        //        {

        //        }

        //        paymentID = payment.PaymentID;

        //        //SERVICES

        //        var servicePayments = db.ServicesPayments.Where(a => a.PaymentID == invoiceNumber).ToList();

        //        if (servicePayments.Count > 0)
        //        {
        //            servicePayments.ForEach(service =>
        //            {

        //            });
        //        }
        //        else
        //        {

        //        }


        //        //PATIENT
        //        var patient = db.Patients.FirstOrDefault(a => a.PatientID == payment.PatientID);


        //        PrintVM printVM = new PrintVM
        //        {
        //            InvoiceNumber = payment.PaymentID,
        //            BillDate = payment.BillDate,
        //            DueDate = payment.DueDate,
        //            PatientName = $"{patient.FirstName} {patient.MiddleName} {patient.LastName}".Trim(),
        //            MobileNumber = patient.MobileNumber,
        //            Address = patient.Address,
        //            Balance = balance,
        //            InVoiceGeneratedBy = $"{createdByUser.FirstName} {createdByUser.FirstName} {createdByUser.FirstName}".Trim(),
        //            Notes = payment.Notes,
        //            SubTotal = payment.Total_Amount,
        //            Discount = payment.Discount,
        //            PhilHealthTotal = payment.PhilHealth_Deduction,
        //            TotalPayment = payment.Final_Amount
        //        };

        //        return printVM;
        //    }
        //    catch (Exception ex)
        //    {
        //        // Log the exception or handle it as needed
        //        Console.WriteLine($"Error: {ex.Message}");
        //        return null; // or throw the exception to be handled elsewhere
        //    }
        //}

        public async Task<PrintDTO> PaymentVM(int? invoiceNumber)
        {
            if (!invoiceNumber.HasValue)
            {
                return null; 
            }

            var payment =  _unitOfWork.Repository<Payments>()
                .AsQueryable()
                .Include(a => a.Patient)
                .Include(a => a.CreatedBy)
                .Include(a => a.Staff)
                .FirstOrDefault(a => a.PaymentID == invoiceNumber);

            if (payment == null)
            {
                return null; 
            }

            var items =  _unitOfWork.Repository<ItemPayments>()
                .AsQueryable()
                .Include(a => a.Items) 
                .Where(a => a.PaymentID == invoiceNumber)
                .ToList();

    
            var services =  _unitOfWork.Repository<ServicesPayment>()
                .AsQueryable()
                .Include(a => a.Services)
                .Where(a => a.PaymentID == invoiceNumber)
                .ToList();


            var patientPayments = _unitOfWork.Repository<PatientPayments>()
                .AsQueryable()
                .Include(a => a.Patients)
                .Where(a => a.PaymentID == invoiceNumber)
                .ToList();

    
            return new PrintDTO
            {
                Payments = payment,
                Items = items, 
                Services = services,
                Patients = patientPayments
            };
        }



        public async Task<CommonResponse> deleyePayment(int paymentId)
        {
            var payment = await _unitOfWork.Repository<Payments>().AsQueryable().FirstOrDefaultAsync(a => a.PaymentID == paymentId);

            _unitOfWork.Repository<Payments>().Remove(payment);
            await _unitOfWork.Complete();

            return new CommonResponse(true, "Payment Sucessfully Deleted!");
        }

        public async Task<BillingAndPrintVM> generateInvoiceModel(int? id)
        {

            if (id == null)
            {


                BillingDTO billingDTO = new BillingDTO();

                return new BillingAndPrintVM
                {
                    BillingDTO = billingDTO,
                    PrintDTO = null,
                };

            }
            else
            {

                var payment = _unitOfWork.Repository<Payments>()
                .AsQueryable()
                .Include(a => a.Patient)
                .Include(a => a.CreatedBy)
                .Include(a => a.Staff)
                .FirstOrDefault(a => a.PaymentID == id);

                if (payment == null)
                {
                    return null;
                }

                var items = _unitOfWork.Repository<ItemPayments>()
                    .AsQueryable()
                    .Include(a => a.Items)
                    .Where(a => a.PaymentID == id)
                    .ToList();


                var services = _unitOfWork.Repository<ServicesPayment>()
                    .AsQueryable()
                    .Include(a => a.Services)
                    .Where(a => a.PaymentID == id)
                    .ToList();


                var patientPayments = _unitOfWork.Repository<PatientPayments>()
                    .AsQueryable()
                    .Include(a => a.Patients)
                    .Where(a => a.PaymentID == id)
                    .ToList();

                BillingDTO billingDTO = new BillingDTO();

                PrintDTO printDTO = new PrintDTO
                {
                    Payments = payment,
                    Items = items,
                    Services = services,
                    Patients = patientPayments
                };

                return new BillingAndPrintVM
                {
                    BillingDTO = billingDTO,
                    PrintDTO = printDTO,
                };
            }
           
        }


    }
}
