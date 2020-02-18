using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmptyWeb
{
	public class EmailMessageSender : IMessageSender
	{
		public string Send()
		{
			return "Sent by Email";
		}
	}

}