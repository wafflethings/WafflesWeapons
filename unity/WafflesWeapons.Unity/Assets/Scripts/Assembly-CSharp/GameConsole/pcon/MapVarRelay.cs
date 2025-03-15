using Logic;

namespace GameConsole.pcon
{
	[ConfigureSingleton(SingletonFlags.PersistAutoInstance)]
	public class MapVarRelay : MonoSingleton<MapVarRelay>
	{
		private void Start()
		{
		}

		private void ReceiveChange(string name, object value)
		{
		}

		public void UpdateMapVars(VarStore store)
		{
		}
	}
}
