using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.ApplicationServices.API.Domain.Models;
using TaskManager.DataAccess.Entities;

namespace TaskManager.ApplicationServices.API.Profiles
{
    public class AssgnmentsProfile : Profile
    {
        public AssgnmentsProfile()
        {
            CreateMap<Assignment, AssignmentsDto>()
                .ForMember(x => x.Id, y => y.MapFrom(z => z.Id))
                .ForMember(x => x.Tilte, y => y.MapFrom(z => z.Tilte))
                .ForMember(x => x.Description, y => y.MapFrom(z => z.Description))
                .ForMember(x => x.StartTime, y => y.MapFrom(z => z.StartTime))
                .ForMember(x => x.EndTime, y => y.MapFrom(z => z.EndTime))
                .ForMember(x => x.DeadlineTime, y => y.MapFrom(z => z.DeadlineTime))
                .ForMember(x => x.CustomerId, y => y.MapFrom(z => z.CustomerId))
                .ForMember(x => x.Customer, y => y.MapFrom(z => z.Customer))
                .ForMember(x => x.BoardId, y => y.MapFrom(z => z.BoardId))
                .ForMember(x => x.Board, y => y.MapFrom(z => z.Board))
                .ForMember(x => x.CommentsList, y => y.MapFrom(z => z.CommentsList))
                .ForMember(x => x.AssignmentStatus, y => y.MapFrom(z => z.AssignmentStatus));
        }
    }
}
