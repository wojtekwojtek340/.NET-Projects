using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.ApplicationServices.API.Domain.Customers;
using TaskManager.ApplicationServices.API.Domain.Models;
using TaskManager.DataAccess.Entities;

namespace TaskManager.ApplicationServices.API.Profiles
{
    class CustomersProfile : Profile
    {
        public CustomersProfile()
        {
            CreateMap<Customer, CustomerDto>()
                .ForMember(x => x.Id, y => y.MapFrom(z => z.Id))
                .ForMember(x => x.Name, y => y.MapFrom(z => z.Name))
                .ForMember(x => x.AssignmentList, y => y.MapFrom(z => z.AssignmentList));

            CreateMap<AddCustomerRequest, Customer>()
                //.ForMember(x => x.Id, y => y.MapFrom(z => z.Id))
                .ForMember(x => x.Name, y => y.MapFrom(z => z.Name));
            //.ForMember(x => x.AssignmentList, y => y.MapFrom(z => z.AssignmentList));

            CreateMap<PutCustomerByIdRequest, Customer>()
                .ForMember(x => x.Id, y => y.MapFrom(z => z.Id))
                //.ForMember(x => x.Id, y => y.MapFrom(z => z.Id))
                .ForMember(x => x.Name, y => y.MapFrom(z => z.Name));
                //.ForMember(x => x.AssignmentList, y => y.MapFrom(z => z.AssignmentList));
        }
    }
}
