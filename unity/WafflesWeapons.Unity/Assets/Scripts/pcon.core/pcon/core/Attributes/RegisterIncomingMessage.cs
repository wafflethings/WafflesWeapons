using System;

namespace pcon.core.Attributes
{
	[AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = false)]
	public class RegisterIncomingMessage : Attribute
	{
		public string type { get; }

		public RegisterIncomingMessage(string type)
		{
		}
	}
}
