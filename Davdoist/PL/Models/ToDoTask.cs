using System;
using System.ComponentModel.DataAnnotations;

namespace PL.Models
{
    public class ToDoTask
    {
        public int Id { get; set; }

        [Display(Name = "Header")]
        public string Header { get; set; }

        [Display(Name = "Is completed")]
        public bool IsCompleted { get; set; }

        [Display(Name = "Description")]
        public string Description { get; set; } = null;

        [DataType(DataType.Date)]
        [Display(Name = "DeadLine")]
        public DateTime? Date { get; set; } = null;

        [Display(Name = "Priority")]
        public Priority Priority { get; set; } = Priority.None;

        [Display(Name = "Folder: ")]
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
