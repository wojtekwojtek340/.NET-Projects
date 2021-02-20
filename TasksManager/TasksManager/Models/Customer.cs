﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TasksManager.Models
{
    public class Customer
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public List<Task> TasksList { get; set; }
    }
}
