using SaleSystem.Core.DTO;

namespace SaleSystem.Core.Services.Contract
{
    public interface IUserService
    {
        Task<List<UserDTO>> GetList();
        Task<UserDTO> Create(UserDTO model);
        Task<bool> Update(UserDTO model);
        Task<bool> Delete(Guid id);
        Task<SessionDTO> Login(string email, string password, string key);
    }
}
