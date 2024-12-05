﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using NatalCare.DataAccess.data;
using NatalCare.DataAccess.Interfaces;
using NatalCare.DataAccess.Repository.IRepository;
using NatalCare.Models.DTOs;
using NatalCare.Models.DTOs.VM;
using NatalCare.Models.Entities;
using System.Security.Claims;
using static Azure.Core.HttpHeader;
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

            var payments = await _unitOfWork.Repository<Payments>().AsQueryable().Include(a => a.Patient).Include(a => a.Staff).Include(a => a.CreatedBy).OrderBy(a => a.Payment_Status).ToListAsync();

            var patientPayments = await _unitOfWork.Repository<PatientPayments>().AsQueryable().Include(a => a.Patients).Include(a => a.Payments).ToListAsync();

            return new InvoiceListDTO
            {
                Payments = payments,
                PatientPayments = patientPayments
            };
        }

        public async Task<List<PatientPayments>> GetPatientPaymentHistory(int paymentId)
        {
            var patientPayments = await _unitOfWork.Repository<PatientPayments>().AsQueryable().Include(a => a.Patients).Include(a => a.Payments).Where(a => a.PaymentID == paymentId).ToListAsync();

            return patientPayments;
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

        public async Task<PrintInvoiceResponse> editInvoice(BillingDTO billingDTO)
        {
            var userId = _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var user = await _userManager.Users.FirstOrDefaultAsync(a => a.Id == userId);

            var invoice = await _unitOfWork.Repository<Payments>().AsQueryable().FirstOrDefaultAsync(a => a.PaymentID == billingDTO.paymentID);

            if (invoice == null)
            {
                return new PrintInvoiceResponse(false, 0);
            }

            var patient = await _unitOfWork.Repository<Patients>().AsQueryable().FirstOrDefaultAsync(a => a.PatientID == billingDTO.PatientName);

            invoice.PatientID = patient.PatientID;
            invoice.Total_Amount = billingDTO.SubTotal;
            invoice.Final_Amount = billingDTO.TotalAmount;
            invoice.Discount = billingDTO.Discount;
            invoice.PhilHealth_Deduction = billingDTO.PhilHeathTotal;
            invoice.Notes = billingDTO.Notes;
            invoice.BillDate = billingDTO.BillDate;
            invoice.DueDate = billingDTO.DueDate;
            invoice.Updated_At = DateTime.Now;
            invoice.PatientUpdatedBy = user.Id;
            invoice.StaffID = int.Parse(billingDTO.StaffName);

            _unitOfWork.Repository<Payments>().Update(invoice);

            foreach (var item in billingDTO.Items)
            {
                var itemPayment = await _unitOfWork.Repository<ItemPayments>().AsQueryable().Include(a => a.Items).FirstOrDefaultAsync(a => a.PaymentID == billingDTO.paymentID && a.Items.ItemName == item.ItemName);

                if(itemPayment != null)
                {
                    itemPayment.Quantity = item.Quantity;
                    itemPayment.PhilHealthCovered = item.PhilHealthCovered;

                    _unitOfWork.Repository<ItemPayments>().Update(itemPayment);
                }
                else
                {
                    var ogItem = await _unitOfWork.Repository<Items>().GetFirstOrDefaultAsync(a => a.ItemName == item.ItemName);

                    ItemPayments itemPayments2 = new ItemPayments
                    {
                        PaymentID = billingDTO.paymentID,
                        ItemID = ogItem.ItemID,
                        Quantity = item.Quantity,
                        PhilHealthCovered = item.PhilHealthCovered
                    };

                    _unitOfWork.Repository<ItemPayments>().Add(itemPayments2);

                }
            }

            foreach (var service in billingDTO.Services)
            {
                var servicePayment = await _unitOfWork.Repository<ServicesPayment>().AsQueryable().Include(a => a.Services).FirstOrDefaultAsync(a => a.PaymentID == billingDTO.paymentID && a.Services.ServiceName == service.ServiceName);

                if (servicePayment != null)
                {
                    servicePayment.Quantity = service.Quantity;
                    servicePayment.PhilhealthCovered = service.PhilHealthCovered;

                    _unitOfWork.Repository<ServicesPayment>().Update(servicePayment);
                }
                else
                {
                    var ogService = await _unitOfWork.Repository<Servicesss>().GetFirstOrDefaultAsync(a => a.ServiceName == service.ServiceName);

                    ServicesPayment servicePayment2 = new ServicesPayment
                    {
                        PaymentID = billingDTO.paymentID,
                        ServiceID = ogService.ServiceID,
                        Quantity = service.Quantity,
                        PhilhealthCovered = service.PhilHealthCovered
                    };

                    _unitOfWork.Repository<ServicesPayment>().Add(servicePayment2);

                }
            }

            var patientPayment = await _unitOfWork.Repository<PatientPayments>().AsQueryable().Include(a => a.Payments).Where(a => a.PaymentID == invoice.PaymentID).ToListAsync();


            decimal? final_amount = 0;

            decimal? totalPaid = 0;

            if (patientPayment.Count > 0)
            {
                List<decimal?> paidAmount = new List<decimal?>();

                foreach (var payment1 in patientPayment)
                {
                    paidAmount.Add(payment1.Amount);
                    final_amount = payment1?.Payments?.Final_Amount;
                }

                totalPaid = paidAmount.Sum(x => x ?? 0);
            }

            var payment = await _unitOfWork.Repository<Payments>().AsQueryable().FirstOrDefaultAsync(a => a.PaymentID == invoice.PaymentID);


            if (totalPaid != 0)
            {
                if (final_amount == totalPaid || totalPaid > final_amount)
                {
                    payment.Payment_Status = "PAID";
                }
                else
                {
                    payment.Payment_Status = "PARTIAL";
                }
            }
            else
            {
                payment.Payment_Status = "PENDING";
            }

            _unitOfWork.Repository<Payments>().Update(payment);
            await _unitOfWork.Complete();

            return new PrintInvoiceResponse(true, billingDTO.paymentID);

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

        public async Task<CommonResponse> deletePatientPayment(int? paymentId)
        {
            var payment11 = await _unitOfWork.Repository<PatientPayments>().AsQueryable().FirstOrDefaultAsync(a => a.PatientPaymentID == paymentId);

            _unitOfWork.Repository<PatientPayments>().Remove(payment11);
            await _unitOfWork.Complete();

            var patientPayment = await _unitOfWork.Repository<PatientPayments>().AsQueryable().Include(a => a.Payments).Where(a => a.PaymentID == payment11.PaymentID).ToListAsync();

            decimal? final_amount = 0;

            decimal? totalPaid = 0;

            if (patientPayment.Count > 0)
            {
                List<decimal?> paidAmount = new List<decimal?>();

                foreach (var payment1 in patientPayment)
                {
                    paidAmount.Add(payment1.Amount);
                    final_amount = payment1?.Payments?.Final_Amount;
                }

                totalPaid = paidAmount.Sum(x => x ?? 0);
            }

            var payment = await _unitOfWork.Repository<Payments>().AsQueryable().FirstOrDefaultAsync(a => a.PaymentID == payment11.PaymentID);


            if (totalPaid != 0)
            {
                if (final_amount == totalPaid || totalPaid > final_amount)
                {
                    payment.Payment_Status = "PAID";
                }
                else
                {
                    payment.Payment_Status = "PARTIAL";
                }
            }
            else
            {
                payment.Payment_Status = "PENDING";
            }

            _unitOfWork.Repository<Payments>().Update(payment);
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

        public async Task<PatientPayments> payInvoice()
        {
            var model = new PatientPayments();

            return model;
        }


        public async Task<string> patientID(int? id)
        {
            var model =  await _unitOfWork.Repository<Payments>().AsQueryable().FirstOrDefaultAsync(a => a.PaymentID == id);

            return model.PatientID;
        }

        public async Task<CommonResponse> addPatientPayment(PatientPayments? patientPayments)
        {

            PatientPayments newPatientPayment = new PatientPayments
            {
                Amount = patientPayments.Amount,
                Payment_Method = patientPayments.Payment_Method,
                PaymentID = patientPayments.PaymentID,
                DatePaid = DateTime.Now,
                PatientID = patientPayments.PatientID,
            };

            _unitOfWork.Repository<PatientPayments>().Add(newPatientPayment);
            await _unitOfWork.Complete();


            var patientPayment = await _unitOfWork.Repository<PatientPayments>().AsQueryable().Include(a => a.Payments).Where(a => a.PaymentID == patientPayments.PaymentID).ToListAsync();


            decimal? final_amount = 0;

            decimal? totalPaid = 0;

            if (patientPayment.Count > 0)
            {
                List<decimal?> paidAmount = new List<decimal?>();

                foreach (var payment1 in patientPayment)
                {
                    paidAmount.Add(payment1.Amount);
                    final_amount = payment1?.Payments?.Final_Amount;
                }

                totalPaid = paidAmount.Sum(x => x ?? 0);
            }

            var payment = await _unitOfWork.Repository<Payments>().AsQueryable().FirstOrDefaultAsync(a => a.PaymentID == patientPayments.PaymentID);

            if (totalPaid != 0)
            {
                if (final_amount == totalPaid || totalPaid > final_amount)
                {
                    payment.Payment_Status = "PAID";
                }
                else
                {
                    payment.Payment_Status = "PARTIAL";
                }
            }
            else
            {
                payment.Payment_Status = "PENDING";
            }

            _unitOfWork.Repository<Payments>().Update(payment);
            await _unitOfWork.Complete();

            return new CommonResponse(true, "Payment for Patient added Succesffully!");
        }


        public async Task<CommonResponse> editPatientPayment(PatientPayments? patientPayments)
        {

            var patientPayment = await _unitOfWork.Repository<PatientPayments>().GetFirstOrDefaultAsync(a => a.PatientPaymentID == patientPayments.PatientPaymentID);

            patientPayment.Amount = patientPayments?.Amount;
            patientPayment.Payment_Method = patientPayments?.Payment_Method;

            _unitOfWork.Repository<PatientPayments>().Update(patientPayment);
            await _unitOfWork.Complete();


            var patientPayment1 = await _unitOfWork.Repository<PatientPayments>().AsQueryable().Include(a => a.Payments).Where(a => a.PaymentID == patientPayment.PaymentID).ToListAsync();

            decimal? final_amount = 0;

            decimal? totalPaid = 0;

            if (patientPayment1.Count > 0)
            {
                List<decimal?> paidAmount = new List<decimal?>();

                foreach (var payment1 in patientPayment1)
                {
                    paidAmount.Add(payment1.Amount);
                    final_amount = payment1?.Payments?.Final_Amount;
                }

                totalPaid = paidAmount.Sum(x => x ?? 0);
            }

            var payment = await _unitOfWork.Repository<Payments>().AsQueryable().FirstOrDefaultAsync(a => a.PaymentID == patientPayment.PaymentID);

            if (totalPaid != 0)
            {
                if (final_amount == totalPaid || totalPaid > final_amount)
                {
                    payment.Payment_Status = "PAID";
                }
                else
                {
                    payment.Payment_Status = "PARTIAL";
                }
            }
            else
            {
                payment.Payment_Status = "PENDING";
            }

            _unitOfWork.Repository<Payments>().Update(payment);
            await _unitOfWork.Complete();


            return new CommonResponse(true, "Patient Payment Updated Successfully!");
        }

        public async Task<dynamic> GetDataByYearAndMonth(int? year, string? month)
        {
            var query = _unitOfWork.Repository<Payments>().AsQueryable();

            if (year.HasValue)
            {
                query = query.Where(d => d.Created_At.HasValue && d.Created_At.Value.Year == year.Value);

                if (!string.IsNullOrEmpty(month))
                {
                    query = query.Where(d => d.Created_At.Value.Month.ToString("D2") == month);
                }
            }

            var data = await query.ToListAsync();

            var yearlyData = new
            {
                TotalPayments = data.Count,
                TotalAmount = data.Sum(d => d.Total_Amount) ?? 0,
                TotalDiscount = data.Sum(d => d.Discount) ?? 0,
            };

            return yearlyData;
        }

        public async Task<dynamic> GetPaymentStatusStatistics()
        {
            var payments = await _unitOfWork.Repository<Payments>().AsQueryable()
                .Include(a => a.Patient).Include(a => a.Staff).Include(a => a.CreatedBy)
                .OrderBy(a => a.Payment_Status).ToListAsync();

            int paid = 0;
            int partial = 0;
            int pending = 0;


            foreach (var payment in payments)
            {
                if (payment.Payment_Status == "PAID")
                {
                    paid++;
                }
                else if(payment.Payment_Status == "PARTIAL")
                {
                    partial++;
                }
                else
                {
                    pending++;
                }
            }

            var data = new
            {
                paid = paid,    
                partial = partial,
                pending = pending,
            };

            return data;
        }
    }
}
