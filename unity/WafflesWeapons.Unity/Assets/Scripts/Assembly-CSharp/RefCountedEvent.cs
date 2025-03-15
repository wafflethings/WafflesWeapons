using UnityEngine;
using UnityEngine.Events;

public sealed class RefCountedEvent : MonoBehaviour
{
	private int m_RefCount;

	[SerializeField]
	private UnityEvent m_Activate;

	[SerializeField]
	private UnityEvent m_Deactivate;

	public void AddRef()
	{
	}

	public void Release()
	{
	}
}
