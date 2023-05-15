using SaleSystem.Core.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaleSystem.Core.Services.Contract
{
    public interface IDashBoardService
    {
        Task<DashBoardDTO> Summary();
    }
}
