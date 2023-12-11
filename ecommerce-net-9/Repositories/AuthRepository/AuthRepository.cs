using ecommerce_net_9.Data;
using ecommerce_net_9.DTOs.APIUserDTOs.Request;
using ecommerce_net_9.DTOs.APIUserDTOs.Response;
using ecommerce_net_9.Models.AuthModels;
using Microsoft.AspNetCore.Identity;

namespace ecommerce_net_9.Repositories.AuthRepository
{
    public class AuthRepository : IAuthRepository
    {
        private readonly UserManager<ApiUser> userManager;
        private readonly IConfiguration configuration;
        private readonly ApplicationDbContext dbContext;

        public AuthRepository(
            UserManager<ApiUser> userManager,
            IConfiguration configuration,
            ApplicationDbContext dbContext)
        {
            this.userManager = userManager;
            this.configuration = configuration;
            this.dbContext = dbContext;
        }
        public async Task<Response_ApiUserRegisterDTO> Register(Request_ApiUserRegisterDTO userDTO)
        {
            var user = new ApiUser()
            {
                FirstName = userDTO.FirstName,
                LastName = userDTO.LastName,
                Email = userDTO.Email,
            };

            user.UserName = userDTO.Email;
            user.EmailConfirmed = true;

            var result = await userManager.CreateAsync(user, userDTO.Password);

            if (result.Succeeded)
            {
                await userManager.AddToRoleAsync(user, Constants.Roles.Customer);

                return new Response_ApiUserRegisterDTO()
                {
                    IsSuccess = true,
                    ApiUser = user,

                };
            }

            List<string> errors = new List<string>();

            foreach (var error in result.Errors)
            {
                errors.Add(error.Description.ToString());
            }

            return new Response_ApiUserRegisterDTO()
            {
                IsSuccess = true,
                Message = errors
            };

        }

        public async Task<Response_ApiUserRegisterDTO> RegisterAdmin(Request_ApiUserRegisterDTO userDTO, int secretKey)
        {

            if (secretKey != 12345)
            {
                return new Response_ApiUserRegisterDTO()
                {
                    IsSuccess = true,
                    Message = new List<string>()
                {
                    "Invalid Secret Key"
                }
                };
            }

            var user = new ApiUser()
            {
                FirstName = userDTO.FirstName,
                LastName = userDTO.LastName,
                Email = userDTO.Email,
            };

            user.UserName = userDTO.Email;
            user.EmailConfirmed = true;

            var result = await userManager.CreateAsync(user, userDTO.Password);

            if (result.Succeeded)
            {
                await userManager.AddToRoleAsync(user, Constants.Roles.Admin);

                return new Response_ApiUserRegisterDTO()
                {
                    IsSuccess = true,
                    ApiUser = user,

                };
            }

            List<string> errors = new List<string>();

            foreach (var error in result.Errors)
            {
                errors.Add(error.Description.ToString());
            }

            return new Response_ApiUserRegisterDTO()
            {
                IsSuccess = true,
                Message = errors
            };
        }
    }
}
