using System;

namespace BLL.Entities
{
    public class ToDoTask
    {
        public int Id { get; set; }

        public string Header { get; set; }

        public bool IsCompleted { get; set; }

        public string Description { get; set; } = null;

        public DateTime? Date { get; set; } = null;

        public Priority Priority { get; set; } = Priority.None;

        public int? FolderId { get; set; }
    }

    public enum Priority
    {
        None,
        Low,
        Medium,
        High
    }
}
