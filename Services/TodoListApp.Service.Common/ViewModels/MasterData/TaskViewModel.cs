using System;
using System.Collections.Generic;
using System.Text;

namespace TodoListApp.Service.Common.ViewModels.MasterData
{
    public class TaskViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTimeOffset? StartDateAt { get; set; }
        public DateTimeOffset? FinishedDateAt { get; set; }
        public string ThumbTask { get; set; }
        public string Remark { get; set; }
        public decimal? EstimationTime { get; set; }
        public int StatusKey { get; set; }
        public string StatusDescription { get; set; }
    }
}
