using MultiShop.DtoLayer.Dtos.IdentityDtos.UserDtos;

namespace MultiShop.WebUI.Services.UserIdentityServices
{
    public interface IUserIdentityService
    {
        Task<List<ResultUserDto>> GetAllUserListAsync();
    }
}
