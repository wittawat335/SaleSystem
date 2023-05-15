using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaleSystem.Core.DTO
{
    public class SaleDTO
    {
        public int SaleId { get; set; }

        public string? DocumentNumber { get; set; }

        public string? PaymentType { get; set; }

        public string? TotalText { get; set; }

        public string? CreateDate { get; set; }
        public virtual ICollection<SaleDetailDTO>? SaleDetails { get; set; }
    }
}
