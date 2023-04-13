using MotorcycleWebShop.Application.Common.Interfaces;
using System.Security.Claims;

namespace MotorcycleWebShop.Services
{
    public class CurrentUserService : ICurrentUserService
    {
        private readonly IHttpContextAccessor _context;

        public CurrentUserService(
            IHttpContextAccessor context)
        {
            _context = context;
        }

        public int UserId => int.Parse(_context.HttpContext?.User?.FindFirstValue(ClaimTypes.NameIdentifier));
    }
}
