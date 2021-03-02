using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.ApplicationServices.API.Domain.Boards;
using TaskManager.ApplicationServices.API.Domain.Models;
using TaskManager.DataAccess.Entities;

namespace TaskManager.ApplicationServices.API.Profiles
{
    class BoardsProfile : Profile
    {
        public BoardsProfile()
        {
            CreateMap<Board, BoardsDto>()
                .ForMember(x => x.Id, y => y.MapFrom(z => z.Id))
                .ForMember(x => x.AssignmentList, y => y.MapFrom(z => z.AssignmentList))             
                .ForMember(x => x.Employee, y => y.MapFrom(z => z.Employee));

            CreateMap<AddBoardRequest, Board>()
                //.ForMember(x => x.Id, y => y.MapFrom(z => z.Id))
                //.ForMember(x => x.AssignmentList, y => y.MapFrom(z => z.AssignmentList))
                .ForMember(x => x.EmployeeId, y => y.MapFrom(z => z.EmployeeId));
                //.ForMember(x => x.Employee, y => y.MapFrom(z => z.Employee));
        }
    }
}
