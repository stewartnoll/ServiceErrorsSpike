using System.Collections.Generic;
using Foo.Email.Expectations;

namespace Foo.Email.Models
{
    public class ErrorResponse
    {
        public List<ValidationError> ValidationErrors { get; set; }
    }
}