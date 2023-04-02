using Domain.Quiz.Abstracts;
using MediatR;
using System;

namespace Api.Quiz.Middelwares
{
    public class ExceptionMiddleware : IMiddleware
    {
        private readonly IMediator _mediator;
        public ExceptionMiddleware(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next(context);
            }
            catch(DomainException domainException)
            {
                context.Response.StatusCode = domainException.StatusCode;
                await context.Response.WriteAsJsonAsync(new ErrorResponse
                {
                    StatusCode = domainException.StatusCode,
                    Errors = domainException.Errors,
                    StackTrace = domainException.StackTrace ?? "",
                });
            }
            catch (Exception exception)
            {
                context.Response.StatusCode = 500;
                await context.Response.WriteAsJsonAsync(new ErrorResponse
                {
                    StatusCode = 500,
                    Errors = new Dictionary<string, string>
                    {
                        {"", exception.Message },
                    },
                    StackTrace = exception.StackTrace ?? "",
                    Message= exception.Message,
                });
            }
        }
    }
}
