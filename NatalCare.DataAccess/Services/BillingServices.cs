using NatalCare.DataAccess.Interfaces;
using NatalCare.DataAccess.Repository.IRepository;
using NatalCare.Models.Entities;
using static NatalCare.DataAccess.Response.ServiceResponses;

namespace NatalCare.DataAccess.Services
{
    public class BillingServices : IBillingServices
    {

        private readonly IAppUnitOfWork _unitOfWork;

        public BillingServices(IAppUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
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
    }
}
