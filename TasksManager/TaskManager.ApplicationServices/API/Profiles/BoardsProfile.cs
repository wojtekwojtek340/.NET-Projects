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
    class BoardsProfile : Profile
    {
        public BoardsProfile()
        {
            CreateMap<BoardDto, Board>();
            CreateMap<Board, BoardDto>();
        }
    }
}
