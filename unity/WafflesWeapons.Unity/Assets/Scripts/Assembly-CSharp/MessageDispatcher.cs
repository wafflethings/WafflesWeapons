using UnityEngine;
using UnityEngine.Events;

public abstract class MessageDispatcher : MessageDispatcherBase
{
	[SerializeField]
	private UnityEvent _handler;

	public new UnityEvent Handler => null;

	public void AddListener(UnityAction action)
	{
	}

	public void RemoveListener(UnityAction action)
	{
	}

	public new void RemoveAllListeners()
	{
	}

	protected sealed override UnityEventBase GetHandler()
	{
		return null;
	}
}
public abstract class MessageDispatcher<T> : MessageDispatcherBase
{
	public abstract class Callback<TEvent> : MessageDispatcher<T> where TEvent : UnityEvent<T>, new()
	{
		[SerializeField]
		private TEvent _handler;

		public sealed override UnityEvent<T> Handler => null;

		public Callback()
		{
		}
	}

	public new abstract UnityEvent<T> Handler { get; }

	private MessageDispatcher()
	{
	}

	public void AddListener(UnityAction<T> action)
	{
	}

	public void RemoveListener(UnityAction<T> action)
	{
	}

	public new void RemoveAllListeners()
	{
	}

	protected sealed override UnityEventBase GetHandler()
	{
		return null;
	}
}
public abstract class MessageDispatcher<T1, T2> : MessageDispatcherBase
{
	public abstract class Callback<TEvent> : MessageDispatcher<T1, T2> where TEvent : UnityEvent<T1, T2>, new()
	{
		[SerializeField]
		private TEvent _handler;

		public sealed override UnityEvent<T1, T2> Handler => null;

		public Callback()
		{
		}
	}

	public new abstract UnityEvent<T1, T2> Handler { get; }

	private MessageDispatcher()
	{
	}

	public void AddListener(UnityAction<T1, T2> action)
	{
	}

	public void RemoveListener(UnityAction<T1, T2> action)
	{
	}

	public new void RemoveAllListeners()
	{
	}

	protected sealed override UnityEventBase GetHandler()
	{
		return null;
	}
}
