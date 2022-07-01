using DAL.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    class ToDoTask
    {
        public int Id { get; set; }

        public string Header { get; set; }

        public bool IsCompleted { get; set; }

        public string Description { get; set; } = null;

        public DateTime? Date { get; set; } = null;

        public Priority Priority { get; set; } = Priority.None;
    }
}
