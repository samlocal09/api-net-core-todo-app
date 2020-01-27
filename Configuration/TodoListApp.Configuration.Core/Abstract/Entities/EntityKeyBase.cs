using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TodoListApp.Configuration.Core.Abstract
{
    public class EntityKeyBase
    {
        [Required]
        public Guid Id { get; set; }

        public EntityKeyBase()
        {
            Id = Guid.NewGuid();
        }
    }
}
