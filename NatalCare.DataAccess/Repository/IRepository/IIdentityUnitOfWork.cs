using Microsoft.AspNetCore.Identity;
using NatalCare.Models.Entities;

namespace NatalCare.DataAccess.Repository.IRepository
{
    public interface IIdentityUnitOfWork
    {
        UserManager<User> UserManager { get; }
        RoleManager<Role> RoleManager { get; }
        SignInManager<User> SignInManager { get; }
    }

}
