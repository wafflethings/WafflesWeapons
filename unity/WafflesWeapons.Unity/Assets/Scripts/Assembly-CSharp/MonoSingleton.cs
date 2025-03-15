using UnityEngine;

[DefaultExecutionOrder(-200)]
public abstract class MonoSingleton : MonoBehaviour
{
}
public abstract class MonoSingleton<T> : MonoSingleton where T : MonoSingleton<T>
{
	private static T instance;

	private static readonly SingletonFlags flags;

	public static T Instance
	{
		get
		{
			return null;
		}
		protected set
		{
		}
	}

	static MonoSingleton()
	{
	}

	private static T Initialize()
	{
		return null;
	}

	protected virtual void Awake()
	{
	}

	protected virtual void OnEnable()
	{
	}

	protected virtual void OnDestroy()
	{
	}
}
