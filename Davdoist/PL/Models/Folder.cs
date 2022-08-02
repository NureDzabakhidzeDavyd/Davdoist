using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PL.Models
{
    public class Folder
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Write folder name")]
        [Range(1,15, ErrorMessage = "Write folder size btw 1 and 15")]
        public string Name { get; set; }

        public List<ToDoTask> Tasks { get; set; } = new List<ToDoTask>();
    }
}
