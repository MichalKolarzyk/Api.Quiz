using Domain.Quiz.Abstracts;
using MediatR;

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
                var errorMessage = await _mediator.Send(domainException);
                context.Response.StatusCode = errorMessage.StatusCode;
                await context.Response.WriteAsJsonAsync(errorMessage);
            }
        }
    }
}
