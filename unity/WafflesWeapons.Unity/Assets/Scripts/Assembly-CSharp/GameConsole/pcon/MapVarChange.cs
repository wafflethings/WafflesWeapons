using pcon.core.Attributes;
using pcon.core.Interfaces;
using plog;

namespace GameConsole.pcon
{
	[RegisterIncomingMessage("ultrakill.mapvar.update")]
	public class MapVarChange : IReceive
	{
		private static readonly Logger Log;

		private const string Type = "ultrakill.mapvar.update";

		public MapVarField variable;

		public string type => null;

		public void Receive()
		{
		}
	}
}
