using System;
using System.Collections.Generic;
using System.Text;

namespace TodoListApp.Service.Common.ViewModels
{
    public class BaseResultsViewModel<T> where T : class
    {
        public bool Success { get; set; }

        public int Code { get; set; }

        public IEnumerable<T> Result { get; set; }
    }
}
