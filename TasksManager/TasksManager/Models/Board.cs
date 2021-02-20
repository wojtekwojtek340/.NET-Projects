using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TasksManager.Models
{
    public class Board
    {
        public int Id { get; set; }

        public Employee Employee { get; set; }

        public List<Task> ToBePlanned { get; set; }

        public List<Task> Planned { get; set; }

        public List<Task> InProgress { get; set; }

        public List<Task> Completed { get; set; }

        public List<Task> Suspended { get; set; }

        public List<Task> Canceled { get; set; }
    }
}
