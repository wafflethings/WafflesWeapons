using UnityEngine;
using UnityEngine.Events;

public abstract class MessageDispatcherBase : MonoBehaviour
{
	public UnityEventBase Handler => null;

	private protected MessageDispatcherBase()
	{
	}

	protected abstract UnityEventBase GetHandler();

	public void RemoveAllListeners()
	{
	}
}
