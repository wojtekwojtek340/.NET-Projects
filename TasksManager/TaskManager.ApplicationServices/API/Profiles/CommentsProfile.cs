using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.ApplicationServices.API.Domain.Comments;
using TaskManager.ApplicationServices.API.Domain.Models;
using TaskManager.DataAccess.Entities;

namespace TaskManager.ApplicationServices.API.Profiles
{
    class CommentsProfile : Profile
    {
        public CommentsProfile()
        {
            CreateMap<Comment, CommentDto>()
                .ForMember(x => x.Id, y => y.MapFrom(z => z.Id))
                .ForMember(x => x.Description, y => y.MapFrom(z => z.Description))
                .ForMember(x => x.AssignmentId, y => y.MapFrom(z => z.AssignmentId))
                .ForMember(x => x.Assignment, y => y.MapFrom(z => z.Assignment));

            CreateMap<AddCommentRequest, Comment>()
                // .ForMember(x => x.Id, y => y.MapFrom(z => z.Id))
                .ForMember(x => x.Description, y => y.MapFrom(z => z.Description))
                .ForMember(x => x.AssignmentId, y => y.MapFrom(z => z.AssignmentId));
                //.ForMember(x => x.Assignment, y => y.MapFrom(z => z.Assignment));

        }
    }
}
