using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    internal class Folder
    {
        public List<ToDoTask> Tasks { get; set; }

        public int Id { get; set; }

        public string Name { get; set; }

        public ToDoTask this[int index]
        {
            get
            {
                try
                {
                    return this.Tasks[index];
                }
                catch (Exception ex)
                {
                    throw ex.InnerException;
                }
            }
            set => this.Tasks[index] = value;
        }
    }
}
