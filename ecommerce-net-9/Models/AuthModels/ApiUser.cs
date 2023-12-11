using Microsoft.AspNetCore.Identity;

namespace ecommerce_net_9.Models.AuthModels
{
    public class ApiUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
