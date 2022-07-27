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

        // If folder doesn't exist - Inbox by default
        public int FolderId { get; set; } = 0;
        public Folder Folder { get; set; }
    }

    public enum Priority
    {
        None,
        Low,
        Media,
        High
    }
}
