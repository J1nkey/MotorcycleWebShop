using Microsoft.AspNetCore.Identity;

namespace MotorcycleWebShop.Domain.Common
{
    public class ApplicationUser : IdentityUser<int>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string IdentificationNumber { get; set; }
        public DateTime Dob { get; set; }
        public string Avatar { get; set; }
    }
}
