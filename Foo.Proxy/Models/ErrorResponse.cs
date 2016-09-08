using System.Collections.Generic;

namespace Foo.Proxy.Models
{
	public class ErrorResponse
	{
		public List<ValidationError> ValidationErrors {get;set;}
	}

	public class ValidationError
	{
		public string PropertyName {get;set;}
		public string Message {get;set;}
	}
}