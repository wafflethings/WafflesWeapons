using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using pcon.core.Interfaces;

namespace GameConsole.pcon
{
	public class Log : ISend
	{
		private const string Type = "pcon.log";

		public string message;

		public string stacktrace;

		[JsonConverter(typeof(StringEnumConverter), new object[] { typeof(CamelCaseNamingStrategy) })]
		public PConLogLevel level;

		public long timestamp;

		public IEnumerable<int> tags;

		public int hash;

		public string type => null;

		private void ComputeHash()
		{
		}
	}
}
