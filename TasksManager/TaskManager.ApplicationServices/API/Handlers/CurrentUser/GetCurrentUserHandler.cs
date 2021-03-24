using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TaskManager.ApplicationServices.API.Domain;
using TaskManager.ApplicationServices.API.Domain.Users;
using TaskManager.ApplicationServices.API.Domain.ErrorHandling;
using TaskManager.ApplicationServices.API.Domain.Models;
using TaskManager.DataAccess.CQRS;
using TaskManager.DataAccess.CQRS.Queries.Employees;
using TaskManager.DataAccess.CQRS.Queries.Managers;

namespace TaskManager.ApplicationServices.API.Handlers.CurrentUser
{
    public class GetCurrentUserHandler : IRequestHandler<GetUserRequest, GetUserResponse>
    {
        private readonly IMapper mapper;
        private readonly IQueryExecutor queryExecutor;

        public GetCurrentUserHandler(IMapper mapper, IQueryExecutor queryExecutor)
        {
            this.mapper = mapper;
            this.queryExecutor = queryExecutor;
        }

        public async Task<GetUserResponse> Handle(GetUserRequest request, CancellationToken cancellationToken)
        {
            dynamic query;
            object mapTypeObject;

            if (request.Me == "Me" || request.Me == "me")
            {
                if (request.AuthenticatorRole == AppRole.Employee)
                {
                    query = new GetEmployeeQuery()
                    {
                        Id = request.AuthenticatorId,
                        CompanyId = request.AuthenticatorCompanyId
                    };
                    mapTypeObject = new EmployeeDto();
                }
                else if (request.AuthenticatorRole == AppRole.Manager)
                {
                    query = new GetManagerQuery()
                    {
                        Id = request.AuthenticatorId,
                        CompanyId = request.AuthenticatorCompanyId
                    };
                    mapTypeObject = new ManagerDto();
                }
                else
                {
                    return new GetUserResponse()
                    {
                        Error = new ErrorModel(ErrorType.Unauthorized)
                    };
                }
            }
            else
            {
                return new GetUserResponse()
                {
                    Error = new ErrorModel(ErrorType.UnsupportedMethod)
                };
            }

            var resorce = await queryExecutor.Execute(query);

            if(resorce == null)
            {
                return new GetUserResponse()
                {
                    Error = new ErrorModel(ErrorType.NotFound)
                };
            }

            var mappedResorce = mapper.Map(resorce, mapTypeObject);

            return new GetUserResponse()
            {
                Data = mappedResorce
            };
        }
    }
}
