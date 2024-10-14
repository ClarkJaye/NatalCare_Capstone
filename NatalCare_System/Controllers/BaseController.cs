using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.Rendering;
using NatalCare.DataAccess.Interfaces;
using System.Security.Claims;

namespace NatalCare_System.Controllers
{
    public class BaseController<T> : Controller where T : class
    {
        private ILogger<T>? _logger;
        protected ILogger<T> Logger => _logger ??= HttpContext.RequestServices.GetRequiredService<ILogger<T>>();
    }
}
