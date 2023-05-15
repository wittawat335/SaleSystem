using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaleSystem.Core.DTO
{
    public class DashBoardDTO
    {
        public int SalesTotal { get; set; }
        public string? TotalIncome { get; set; }
        public int TotalProduct { get; set; }
        public List<SalesWeekDTO>? listSalesWeek { get; set; }
    }
}
