using System;
using System.ComponentModel.DataAnnotations;

namespace PL.Models
{
    public class ToDoTask
    {
        public int Id { get; set; }

        public string Header { get; set; }

        public bool IsCompleted { get; set; }

        public string Description { get; set; } = null;

        [DataType(DataType.Date)]
        public DateTime? Date { get; set; } = null;

        public Priority Priority { get; set; } = Priority.None;

        // If folder doesn't exist - Inbox by default
        public int FolderId { get; set; }
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
