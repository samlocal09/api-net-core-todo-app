using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TodoListApp.WebApi.Models.MasterData
{
    public class TaskViewModel
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public DateTimeOffset? StartDateAt { get; set; }

        public DateTimeOffset? FinishedDateAt { get; set; }

        public string ThumbTask { get; set; }
    }
}
