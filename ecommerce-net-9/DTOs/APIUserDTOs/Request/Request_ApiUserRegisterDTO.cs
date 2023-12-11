using System.ComponentModel.DataAnnotations;

namespace ecommerce_net_9.DTOs.APIUserDTOs.Request
{
    public class Request_ApiUserRegisterDTO
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [StringLength(15, ErrorMessage = "Your password is limited to 2 to 15 characters", MinimumLength = 2)]
        public string Password { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }
    }
}
