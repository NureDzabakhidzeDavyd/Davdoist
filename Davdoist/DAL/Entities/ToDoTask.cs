using System;
using System.ComponentModel.DataAnnotations;

namespace DAL.Entities
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
