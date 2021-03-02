﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.DataAccess.Entities;

namespace TaskManager.ApplicationServices.API.Domain.Comments
{
    public class AddCommentRequest : IRequest<AddCommentResponse>
    {
        public string Description { get; set; }
        public int AssignmentId { get; set; }

       // public Assignment Assignment { get; set; }
    }
}
