using plog.Models;

namespace plog.Handlers
{
	public interface ILogHandler
	{
		Log HandleRecord(Logger source, Log log);
	}
}
