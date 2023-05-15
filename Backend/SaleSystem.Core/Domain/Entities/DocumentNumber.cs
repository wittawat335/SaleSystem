using System;
using System.Collections.Generic;

namespace SaleSystem.Core.Domain;

public partial class DocumentNumber
{
    public int DocumentNumberId { get; set; }

    public int LastNumber { get; set; }

    public DateTime? CreateDate { get; set; }
}
