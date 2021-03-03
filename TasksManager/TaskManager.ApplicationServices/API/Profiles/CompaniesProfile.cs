using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.ApplicationServices.API.Domain.Companies;
using TaskManager.ApplicationServices.API.Domain.Models;
using TaskManager.DataAccess.Entities;

namespace TaskManager.ApplicationServices.API.Profiles
{
    class CompaniesProfile : Profile
    {
        public CompaniesProfile()
        {
            CreateMap<Company, CompanyDto>()
                .ForMember(x => x.Id, y => y.MapFrom(z => z.Id))
                .ForMember(x => x.Description, y => y.MapFrom(z => z.Description))
                .ForMember(x => x.EmployeesList, y => y.MapFrom(z => z.EmployeesList))
                .ForMember(x => x.ManagerId, y => y.MapFrom(z => z.ManagerId));
                //.ForMember(x => x.Manager, y => y.MapFrom(z => z.Manager));

            CreateMap<AddCompanyRequest, Company>()
                //.ForMember(x => x.Id, y => y.MapFrom(z => z.Id))
                .ForMember(x => x.Description, y => y.MapFrom(z => z.Description))
                //.ForMember(x => x.EmployeesList, y => y.MapFrom(z => z.EmployeesList))
                .ForMember(x => x.ManagerId, y => y.MapFrom(z => z.ManagerId));
            //.ForMember(x => x.Manager, y => y.MapFrom(z => z.Manager));

            CreateMap<PutCompanyByIdRequest, Company>()
                .ForMember(x => x.Id, y => y.MapFrom(z => z.Id))
                //.ForMember(x => x.Id, y => y.MapFrom(z => z.Id))
                .ForMember(x => x.Description, y => y.MapFrom(z => z.Description))
                //.ForMember(x => x.EmployeesList, y => y.MapFrom(z => z.EmployeesList))
                .ForMember(x => x.ManagerId, y => y.MapFrom(z => z.ManagerId));
            //.ForMember(x => x.Manager, y => y.MapFrom(z => z.Manager));
        }
    }
}
