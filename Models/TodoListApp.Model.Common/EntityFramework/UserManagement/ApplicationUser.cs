using Microsoft.AspNetCore.Identity;
using System;
using System.ComponentModel.DataAnnotations;
using TodoListApp.Configuration.Core.Interface;

namespace TodoListApp.Model.Common.EntityFramework.UserManagement
{
    public class ApplicationUser : IdentityUser<Guid>, IEntitySystemBase
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        [Required]
        public bool IsDeleted { get; set; }

        [Required]
        public DateTime CreatedAt { get; set; }

        [Required]
        public Guid CreatedBy { get; set; }

        [Required]
        public DateTime UpdatedAt { get; set; }

        [Required]
        public Guid UpdatedBy { get; set; }
    }
}