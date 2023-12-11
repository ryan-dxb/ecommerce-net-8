using ecommerce_net_9.DTOs.APIUserDTOs.Request;
using ecommerce_net_9.DTOs.APIUserDTOs.Response;
using ecommerce_net_9.Models.AuthModels;
using ecommerce_net_9.Repositories.AuthRepository;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ecommerce_net_9.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthRepository authRepository;
        private readonly UserManager<ApiUser> userManager;

        public AuthController(IAuthRepository authRepository, UserManager<ApiUser> userManager)
        {
            this.authRepository = authRepository;
            this.userManager = userManager;
        }


        [HttpPost]
        [Route("register")]
        public async Task<ActionResult<Response_ApiUserRegisterDTO>> Register([FromBody] Request_ApiUserRegisterDTO request_ApiUserRegisterDTO)
        {
            var userDTO = await authRepository.Register(request_ApiUserRegisterDTO);

            if (userDTO.IsSuccess == false)
            {
                return BadRequest(new Response_ApiUserRegisterDTO()
                {
                    IsSuccess = false,
                    Message = userDTO.Message
                });
            }

            // User Confirmation (Optional)

            // var token = await userManager.GenerateEmailConfirmationTokenAsync(userDTO.ApiUser);
            // var confirmationLink = Url.Action("ConfirmEmail", "Auth", new { userId = userDTO.ApiUser.Id, token = token }, Request.Scheme);


            return Ok(new Response_ApiUserRegisterDTO()
            {
                IsSuccess = true,
                ApiUser = userDTO.ApiUser,
            });
        }


        [HttpPost]
        [Route("registerAdmin/{secretKey}")]
        public async Task<ActionResult<Response_ApiUserRegisterDTO>> RegisterAdmin([FromRoute] int secretKey, [FromBody] Request_ApiUserRegisterDTO request_ApiUserRegisterDTO)
        {
            var userDTO = await authRepository.RegisterAdmin(request_ApiUserRegisterDTO, secretKey);

            if (userDTO.IsSuccess == false)
            {
                return BadRequest(new Response_ApiUserRegisterDTO()
                {
                    IsSuccess = false,
                    Message = userDTO.Message
                });
            }

            return Ok(new Response_ApiUserRegisterDTO()
            {
                IsSuccess = true,
                ApiUser = userDTO.ApiUser,
            });
        }
    }
}
