using System.Collections.Generic;
using pcon.core.Interfaces;
using pcon.core.Models;

namespace pcon.core
{
	public class PCon
	{
		private static IPConClient _mountedClient;

		private static List<string> _registeredFeatures;

		private static Handler _handler;

		public static void Internal_RegisterClient(IPConClient client)
		{
		}

		public static void SendMessage(ISend message)
		{
		}

		public static void RegisterFeature(string feature)
		{
		}

		public static void MountHandler(Handler handler)
		{
		}
	}
}
