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
    class CustomersProfile : Profile
    {
        public CustomersProfile()
        {
            CreateMap<Customer, Domain.Models.CustomersDto>()
                .ForMember(x => x.Id, y => y.MapFrom(z => z.Id))
                .ForMember(x => x.Name, y => y.MapFrom(z => z.Name))
                .ForMember(x => x.AssignmentList, y => y.MapFrom(z => z.AssignmentList));
        }
    }
}
