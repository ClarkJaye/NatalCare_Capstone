using NatalCare.DataAccess.Interfaces;
using NatalCare.DataAccess.Repository.IRepository;
using NatalCare.Models.Entities;

namespace NatalCare.DataAccess.Services
{
    internal class NewbornServices : INewbornServices
    {
        private readonly IAppUnitOfWork unitOfWork;

        public NewbornServices(IAppUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<bool> Create(Newborn newborn, string userId)
        {
            if (newborn == null)
                throw new ArgumentNullException(nameof(newborn), "Newborn cannot be null.");

            // Validation checks
            if (await unitOfWork.Repository<Newborn>().AnyAsync(x => x.NewbornID == newborn.NewbornID))
                throw new ArgumentException("Newborn already exists!");

            // Generate a new PatientID
            newborn.NewbornID = GenerateNewbornID();
            newborn.Created_At = DateTime.Now;
            newborn.StatusCode = "AC";
            newborn.NewbornCreatedBy = userId;

            unitOfWork.Repository<Newborn>().Add(newborn);
            return await unitOfWork.Complete() > 0;
        }

        private string GenerateNewbornID()
        {
            var lastPatient = unitOfWork.Repository<Newborn>()
                .AsQueryable()
                .OrderByDescending(p => p.NewbornID)
                .FirstOrDefault();

            int newIdNumber = 1; // Start at 1 if no patients are found

            if (lastPatient != null && lastPatient.NewbornID != null)
            {
                string numericPart = lastPatient.NewbornID.Substring(2);
                newIdNumber = int.Parse(numericPart) + 1;
            }

            return $"NB{newIdNumber:D4}"; 
        }
    }
}
