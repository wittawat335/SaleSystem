using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaleSystem.Core.DTO
{
    public class UserDTO
    {
        public string? UserId { get; set; }
        public string? FullName { get; set; }
        public string? Email { get; set; }
        public int? RoleId { get; set; }
        public string? RoleName { get; set; }
        public string? Password { get; set; }
        public string? PasswordHash { get; set; }
        public int? IsActive { get; set; }
    }
}
