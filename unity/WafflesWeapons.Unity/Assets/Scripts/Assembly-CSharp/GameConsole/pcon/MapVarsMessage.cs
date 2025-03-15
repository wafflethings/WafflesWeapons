using System.Collections.Generic;
using Logic;
using pcon.core.Interfaces;

namespace GameConsole.pcon
{
	public class MapVarsMessage : ISend
	{
		private const string Type = "ultrakill.mapvars";

		public List<MapVarField> variables;

		public bool clear;

		public string type => null;

		public MapVarsMessage(VarStore store)
		{
		}
	}
}
