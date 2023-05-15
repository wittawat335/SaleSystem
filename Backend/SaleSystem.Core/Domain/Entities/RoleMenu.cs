using System;
using System.Collections.Generic;

namespace SaleSystem.Core.Domain;

public partial class RoleMenu
{
    public int MenuRoleId { get; set; }

    public int? MenuId { get; set; }

    public int? RoleId { get; set; }

    public virtual Menu? Menu { get; set; }

    public virtual Role? Role { get; set; }
}
