﻿using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Threading.Tasks;
using TaskManager.ApplicationServices.API.Domain;
using TaskManager.ApplicationServices.API.Domain.ErrorHandling;

namespace TasksManager.Controllers
{
    public abstract class ApiControllerBase : ControllerBase
    {
        private readonly IMediator metiator;

        protected ApiControllerBase(IMediator mediator)
        {
            this.metiator = mediator;
        }

        protected async Task<IActionResult> HandleRequest<TRequest, TResponse>(TRequest request)
            where TRequest : IRequest<TResponse>
            where TResponse : ErrorResponseBase
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(
                    this.ModelState
                    .Where(x => x.Value.Errors.Any())
                    .Select(x => new { property = x.Key, errors = x.Value.Errors }));
            }

            if(User.Claims.FirstOrDefault() != null)
            {
                (request as RequestBase).AuthenticatorName = this.User.FindFirstValue(ClaimTypes.Name);
                (request as RequestBase).AuthenticatorRole = (AppRole)Enum.Parse(typeof(AppRole), this.User.FindFirstValue(ClaimTypes.Role));
                (request as RequestBase).AuthenticatorId = Int32.Parse(this.User.FindFirstValue(ClaimTypes.NameIdentifier));
                (request as RequestBase).AuthenticatorCompanyId = Int32.Parse(this.User.FindFirstValue(ClaimTypes.UserData));
            }          

            var response = await this.metiator.Send(request);
            if(response.Error != null)
            {
                return this.ErrorResponse(response.Error);
            }            
            return this.Ok(response);         
        }

        private IActionResult ErrorResponse(ErrorModel errorModel)
        {
            var httpCode = GetHttpStatusCode(errorModel.Error);
            return StatusCode((int)httpCode, errorModel);
        }

        private object GetHttpStatusCode(string errorType)
        {
            switch(errorType)
            {
                case ErrorType.NotFound:
                    return HttpStatusCode.NotFound;
                case ErrorType.InternalServerError:
                    return HttpStatusCode.InternalServerError;
                case ErrorType.Unauthorized:
                    return HttpStatusCode.Unauthorized;
                case ErrorType.RequestToLarge:
                    return HttpStatusCode.RequestEntityTooLarge;
                case ErrorType.UnsupportedMediaType:
                    return HttpStatusCode.UnsupportedMediaType;
                case ErrorType.UnsupportedMethod:
                    return HttpStatusCode.MethodNotAllowed;
                case ErrorType.TooManyRequests:
                    return (HttpStatusCode)429;
                case ErrorType.NotAuthenticated:
                    return HttpStatusCode.Forbidden;
                case ErrorType.Conflict:
                    return HttpStatusCode.Conflict;
                default:
                    return HttpStatusCode.BadRequest;

            }
        }
    }
}
