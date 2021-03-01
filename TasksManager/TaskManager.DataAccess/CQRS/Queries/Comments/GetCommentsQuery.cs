﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.DataAccess.Entities;

namespace TaskManager.DataAccess.CQRS.Queries.Comments
{
    public class GetCommentsQuery : QueryBase<List<Comment>>
    {
        public override async Task<List<Comment>> Execute(TaskManagerContext context)
        {
            var comments = await context.Comments.ToListAsync();
            return comments;
        }
    }
}
