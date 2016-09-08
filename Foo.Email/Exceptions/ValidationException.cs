using System.Collections.Generic;

namespace Foo.Email.Expectations
{
		public class ValidationException : System.Exception
		{
		public ValidationException() { }
		public ValidationException( string message, List<ValidationError> validationErrors ) : base( message ) 
		{
			ValidationErrors = validationErrors;
		}

		public List<ValidationError> ValidationErrors {get;}
	}
	
}

