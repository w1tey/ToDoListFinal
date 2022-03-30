using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoListFinal.Model
{
    public class TaskModel
    {
        public string? Description { get; set; }
        public bool isFinished { get; set; }

        public TaskModel(string _Description, bool _isFinished)
        {
            Description = _Description;
            isFinished = isFinished;
        }
    }
}
