using pcon.core.Models;

namespace pcon.core.Interfaces
{
	public interface IPConClient
	{
		void SendMessage(ISend message);

		void RegisterFeature(string feature);

		void MountHandler(Handler handler);
	}
}
