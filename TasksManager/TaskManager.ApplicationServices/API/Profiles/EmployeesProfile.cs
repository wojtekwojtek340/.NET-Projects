using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.ApplicationServices.API.Domain.Employees;
using TaskManager.ApplicationServices.API.Domain.Models;
using TaskManager.DataAccess.Entities;

namespace TaskManager.ApplicationServices.API.Profiles
{
    class EmployeesProfile : Profile
    {
        public EmployeesProfile()
        {
            CreateMap<Employee, EmployeesDto>()
                .ForMember(x => x.Id, y => y.MapFrom(z => z.Id))
                .ForMember(x => x.Name, y => y.MapFrom(z => z.Name))
                .ForMember(x => x.Surname, y => y.MapFrom(z => z.Surname))
                .ForMember(x => x.CompanyId, y => y.MapFrom(z => z.CompanyId))
                .ForMember(x => x.Company, y => y.MapFrom(z => z.Company))
                .ForMember(x => x.BoardId, y => y.MapFrom(z => z.BoardId))
                .ForMember(x => x.Board, y => y.MapFrom(z => z.Board));

            CreateMap<AddEmployeeRequest, Employee>()
                //.ForMember(x => x.Id, y => y.MapFrom(z => z.Id))
                .ForMember(x => x.Name, y => y.MapFrom(z => z.Name))
                .ForMember(x => x.Surname, y => y.MapFrom(z => z.Surname))
                .ForMember(x => x.Login, y => y.MapFrom(z => z.Login))
                .ForMember(x => x.Password, y => y.MapFrom(z => z.Password))
                .ForMember(x => x.CompanyId, y => y.MapFrom(z => z.CompanyId))
                //.ForMember(x => x.Company, y => y.MapFrom(z => z.Company))
                .ForMember(x => x.BoardId, y => y.MapFrom(z => z.BoardId));
                //.ForMember(x => x.Board, y => y.MapFrom(z => z.Board));
        }
    }
}
