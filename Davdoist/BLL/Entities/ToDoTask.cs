using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Entities.Enums;

namespace BLL.Entities
{
    class ToDoTask
    {
        public string Header { get; set; }
        public bool IsCompleted { get; set; }
        public string Description { get; set; } = null;
        public DateTime? Date { get; set; } = null;
        public Priority Priority { get; set; } = Priority.None;

    }
}
