using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TodoListApp.Configuration.Core.Abstract;
using TodoListApp.Configuration.Core.Interface;

namespace TodoListApp.Model.Common.EntityFramework.Common
{
    [Table("StateStatus")]
    public class StateStatus : EntityKeyBase, IEntitySystemBase
    {
        public StateStatus()
        {
        }
        public int StatusKey { get; set; }

        public string Description { get; set; }

        [Required]
        public bool IsActive { get; set; }

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
