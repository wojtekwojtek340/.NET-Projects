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
    class ManagersProfile : Profile
    {
        public ManagersProfile()
        {
            CreateMap<Manager, ManagerDto>();
            CreateMap<ManagerDto, Manager>();
        }
    }
}
