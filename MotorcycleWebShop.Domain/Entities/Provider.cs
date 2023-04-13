using MotorcycleWebShop.Domain.Common;

namespace MotorcycleWebShop.Domain.Entities
{
    public class Provider
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
    }
}
