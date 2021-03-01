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
            CreateMap<Manager, Domain.Models.ManagersDto>()
                .ForMember(x => x.Id, y => y.MapFrom(z => z.Id))
                .ForMember(x => x.Name, y => y.MapFrom(z => z.Name))
                .ForMember(x => x.Surname, y => y.MapFrom(z => z.Surname))
                .ForMember(x => x.CompanyId, y => y.MapFrom(z => z.CompanyId))
                .ForMember(x => x.Company, y => y.MapFrom(z => z.Company));
        }
    }
}
