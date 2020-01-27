using System;
using System.Collections.Generic;
using System.Text;

namespace TodoListApp.Service.Common.ViewModels
{
    public class BaseResultViewModel<T> where T : class
    {
        public bool Success { get; set; }

        public int Code { get; set; }

        public T Result { get; set; }
    }
}
