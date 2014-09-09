using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Vaskelista.ViewModels
{
    public class TaskEditViewModel : TaskCreateViewModel
    {
        public Int32 TaskId { get; set; }
    }
}