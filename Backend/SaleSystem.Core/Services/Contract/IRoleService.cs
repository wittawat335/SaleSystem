using SaleSystem.Core.DTO;

namespace SaleSystem.Core.Services.Contract
{
    public interface IRoleService
    {
        Task<List<RoleDTO>> GetList();
    }
}
