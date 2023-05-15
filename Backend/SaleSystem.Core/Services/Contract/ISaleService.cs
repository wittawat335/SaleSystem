using SaleSystem.Core.DTO;

namespace SaleSystem.Core.Services.Contract
{
    public interface ISaleService
    {
        Task<SaleDTO> Register(SaleDTO model);
        Task<List<SaleDTO>> Search(string search,string saleNumber, string startDate, string endDate);
        Task<List<ReportDTO>> Report(string startDate, string endDate);
    }
}
