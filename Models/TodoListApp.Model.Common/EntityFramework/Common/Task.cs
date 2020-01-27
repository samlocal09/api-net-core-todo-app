using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TodoListApp.Configuration.Core.Abstract;
using TodoListApp.Configuration.Core.Interface;

namespace TodoListApp.Model.Common.EntityFramework.Common
{
    [Table("Tasks")]
    public class Task : EntityKeyBase, IEntitySystemBase
    {
        public Task()
        {
        }

        public Task(string name, string description, DateTimeOffset? startDateAt, DateTimeOffset? finishedDateAt, string thumbTask)
        {
            Name = name;
            Description = description;
            StartDateAt = startDateAt;
            FinishedDateAt = finishedDateAt;
            ThumbTask = ThumbTask;
        }

        [MaxLength(255)]
        public string Name { get; set; }

        public string Description { get; set; }

        public DateTimeOffset? StartDateAt { get; set; }

        public DateTimeOffset? FinishedDateAt { get; set; }

        public string ThumbTask { get; set; }

        public string Remark { get; set; }

        [DataType("decimal(2, 18)")]
        public decimal? EstimationTime { get; set; }

        public int StatusKey { get; set; }

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
