using ecommerce_net_9.Models.AuthModels;

namespace ecommerce_net_9.DTOs.APIUserDTOs.Response
{
    public class Response_ApiUserRegisterDTO
    {
        public bool IsSuccess { get; set; }
        public ApiUser ApiUser { get; set; }
        public List<string> Message { get; set; } = new List<string>();
    }
}
