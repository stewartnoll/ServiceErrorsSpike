using System.Collections.Generic;
using Foo.Email.Expectations;
using Microsoft.AspNetCore.Mvc;

namespace Foo.Email.Controllers
{
    [Route("settings")]
    public class EmailSettingsController : ControllerBase
    {
        [HttpGet]
        public GetEmailSettingsResponse GetEmailSettings()
        {
            return new GetEmailSettingsResponse { From = "foobar@foo.com" };
        }

        [HttpPut("1")]
        public UpdateEmailSettingsResponseWithValidationErrors UpdateEmailSettings1([FromBody]UpdateEmailSettingsRequest updateEmailSettingsRequest)
        {
            Response.StatusCode = 400;
            return new UpdateEmailSettingsResponseWithValidationErrors
            {
                ValidationErrors = new List<ValidationError>{
                    new ValidationError 
                    {
                        PropertyName = "from",
                        Message = $"'{updateEmailSettingsRequest.From}' is not a valid email address"
                    }
                }
            };
        }

        [HttpPut("2")]
        public UpdateEmailSettingsResponse UpdateEmailSettings2([FromBody]UpdateEmailSettingsRequest updateEmailSettingsRequest)
        {
            throw new ValidationException("validation error", new List<ValidationError>{
                    new ValidationError
                    {
                        PropertyName = "from",
                        Message = $"'{updateEmailSettingsRequest.From}' is not a valid email address"
                    }
                });
        }

        [HttpPut("3")]
        public UpdateEmailSettingsResponse UpdateEmailSettings3([FromBody]UpdateEmailSettingsRequest updateEmailSettingsRequest)
        {
            return new UpdateEmailSettingsResponse();
        }
    }

    public class GetEmailSettingsResponse
    {
        public string From { get; set; }
    }

    public class UpdateEmailSettingsResponse
    {
    }

    public class UpdateEmailSettingsResponseWithValidationErrors
    {
        public List<ValidationError> ValidationErrors { get; set; }
    }

    public class UpdateEmailSettingsRequest
    {
        public string From { get; set; }
    }
}