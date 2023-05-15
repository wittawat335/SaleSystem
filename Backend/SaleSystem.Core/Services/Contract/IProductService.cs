using SaleSystem.Core.DTO;

namespace SaleSystem.Core.Services.Contract
{
    public interface IProductService
    {
        Task<List<ProductDTO>> GetList();
        Task<ProductDTO> Insert(ProductDTO model);
        Task<bool> Update(ProductDTO model);
        Task<bool> Delete(int id);
    }
}
