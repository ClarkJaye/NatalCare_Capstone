using Microsoft.AspNetCore.Identity;
using NatalCare.DataAccess.Repository.IRepository;
using NatalCare.Models.Entities;

namespace NatalCare.DataAccess.Repository
{
    internal class IdentityUnitOfWork : IIdentityUnitOfWork
    {
        public UserManager<User> UserManager { get; }
        public RoleManager<Role> RoleManager { get; }
        public SignInManager<User> SignInManager { get; }

        public IdentityUnitOfWork(UserManager<User> userManager,
                                  RoleManager<Role> roleManager,
                                  SignInManager<User> signInManager)
        {
            UserManager = userManager;
            RoleManager = roleManager;
            SignInManager = signInManager;
        }
    }

}
