﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager.ApplicationServices.API.Domain.Models
{
    public class CustomerDto
    {
        public int Id { get; set; }        
        public string Name { get; set; }
        public List<AssignmentDto> AssignmentList { get; set; }
    }
}

