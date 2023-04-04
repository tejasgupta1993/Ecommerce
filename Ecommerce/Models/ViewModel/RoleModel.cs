﻿using System.ComponentModel.DataAnnotations;

namespace Ecommerce.Models.ViewModel
{
    public class RoleModel
    {
        [Required]
        public string Role { get; set; }
    }

    public class DeleteRoleModel
    {
        [Required]
        public int RoleId { get; set; }
    }

    public class ShowRoles
    {
        public int RoleId { get; set; }
        public string Role { get; set; }
        public int UserCount { get; set; }
    }
}
