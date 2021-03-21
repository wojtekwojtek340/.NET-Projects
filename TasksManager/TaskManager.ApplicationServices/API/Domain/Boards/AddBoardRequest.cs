using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.DataAccess.Entities;

namespace TaskManager.ApplicationServices.API.Domain.Boards
{
    public class AddBoardRequest : RequestBase, IRequest<AddBoardResponse>
    {
        //public List<Assignment> AssignmentList { get; set; }          
        public int EmployeeId { get; set; }

        //public Employee Employee { get; set; }
    }
}
