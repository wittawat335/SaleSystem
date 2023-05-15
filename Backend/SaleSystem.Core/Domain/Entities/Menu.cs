using System;
using System.Collections.Generic;

namespace SaleSystem.Core.Domain;

public partial class Menu
{
    public int MenuId { get; set; }

    public string? Name { get; set; }

    public string? Icon { get; set; }

    public string? Url { get; set; }

    public virtual ICollection<RoleMenu> RoleMenus { get; set; } = new List<RoleMenu>();
}
