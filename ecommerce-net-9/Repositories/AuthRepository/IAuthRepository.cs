using ecommerce_net_9.DTOs.APIUserDTOs.Request;
using ecommerce_net_9.DTOs.APIUserDTOs.Response;

namespace ecommerce_net_9.Repositories.AuthRepository
{
    public interface IAuthRepository
    {
        Task<Response_ApiUserRegisterDTO> Register(Request_ApiUserRegisterDTO userDTO);
        Task<Response_ApiUserRegisterDTO> RegisterAdmin(Request_ApiUserRegisterDTO userDTO, int secretKey);
    }
}
