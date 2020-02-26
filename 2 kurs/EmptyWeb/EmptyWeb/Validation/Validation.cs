using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;

namespace EmptyWeb
{
	public class Validation
	{
		public ValidationResult Validate(object obj)
		{
			// здесь пробежать по всем полям модели с использованием рефлексии
			// и если они имеют атрибут потомок ValidationAttribute
			// вызвать соответствующий метод IsValid

			return new ValidationResult(true);
		}
	}
}
