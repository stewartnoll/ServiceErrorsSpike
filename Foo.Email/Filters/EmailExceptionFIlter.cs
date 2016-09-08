using System;
using Foo.Email.Expectations;
using Foo.Email.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Foo.Emai.Filters
{
    public class EmailExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            var exception = context.Exception;
            var validationException = exception as ValidationException;
            if (validationException != null)
            {
                var apiResponse = new ErrorResponse { ValidationErrors = validationException.ValidationErrors };
                var result = new ObjectResult(apiResponse);
                result.StatusCode = 400;
                context.Result = result;
            }
        }
    }
}