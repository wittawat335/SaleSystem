using System;
using System.Collections.Generic;

namespace SaleSystem.Core.Domain;

public partial class Sale
{
    public int SaleId { get; set; }

    public string? DocumentNumber { get; set; }

    public string? PaymentType { get; set; }

    public decimal? Total { get; set; }

    public DateTime? CreateDate { get; set; }

    public virtual ICollection<SaleDetail> SaleDetails { get; set; } = new List<SaleDetail>();
}
