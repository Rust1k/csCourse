using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmptyWeb
{
	public class ValidationResult
	{
		public bool IsValid { get; }
		public string ErrMsg { get; }

		public ValidationResult(bool isValid, string errMsg = "")
		{
			IsValid = isValid;
			ErrMsg = errMsg;
		}
	};

	}
}
