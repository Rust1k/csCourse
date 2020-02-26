using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmptyWeb
{
	public abstract class ValidationAttribute : System.Attribute
	{
		public string ErrorMessage { get; set; }
		public abstract bool IsValid(object value);
	}
}
