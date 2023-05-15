using System;
using System.Collections.Generic;

namespace SaleSystem.Core.Domain;

public partial class User
{
    public Guid UserId { get; set; }

    public string? FullName { get; set; }

    public string? Email { get; set; }

    public int? RoleId { get; set; }

    public bool? IsActive { get; set; }

    public DateTime? CreateDate { get; set; }

    public string? Password { get; set; }

    public string? PasswordHash { get; set; }

    public string? Token { get; set; }

    public virtual Role? Role { get; set; }
}
