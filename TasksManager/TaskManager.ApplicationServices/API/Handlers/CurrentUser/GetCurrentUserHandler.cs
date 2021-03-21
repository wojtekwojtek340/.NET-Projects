using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TaskManager.ApplicationServices.API.Domain;
using TaskManager.ApplicationServices.API.Domain.CurrentUser;
using TaskManager.ApplicationServices.API.Domain.ErrorHandling;
using TaskManager.ApplicationServices.API.Domain.Models;
using TaskManager.DataAccess.CQRS;
using TaskManager.DataAccess.CQRS.Queries.Employees;
using TaskManager.DataAccess.CQRS.Queries.Managers;

namespace TaskManager.ApplicationServices.API.Handlers.CurrentUser
{
    public class GetCurrentUserHandler : IRequestHandler<GetCurrentUserRequest, GetCurrentUserResponse>
    {
        private readonly IMapper mapper;
        private readonly IQueryExecutor queryExecutor;

        public GetCurrentUserHandler(IMapper mapper, IQueryExecutor queryExecutor)
        {
            this.mapper = mapper;
            this.queryExecutor = queryExecutor;
        }

        public async Task<GetCurrentUserResponse> Handle(GetCurrentUserRequest request, CancellationToken cancellationToken)
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
                    return new GetCurrentUserResponse()
                    {
                        Error = new ErrorModel(ErrorType.Unauthorized)
                    };
                }
            }
            else
            {
                return new GetCurrentUserResponse()
                {
                    Error = new ErrorModel(ErrorType.UnsupportedMethod)
                };
            }

            var resorce = await queryExecutor.Execute(query);

            if(resorce == null)
            {
                return new GetCurrentUserResponse()
                {
                    Error = new ErrorModel(ErrorType.NotFound)
                };
            }

            var mappedResorce = mapper.Map(resorce, mapTypeObject);

            return new GetCurrentUserResponse()
            {
                Data = mappedResorce
            };
        }
    }
}
