using UnityEngine;
using UnityEngine.Serialization;

[DefaultExecutionOrder(int.MaxValue)]
public sealed class LateCopyPositionAndRotation : MonoBehaviour
{
	[SerializeField]
	[FormerlySerializedAs("target")]
	private Transform m_Target;

	[SerializeField]
	[FormerlySerializedAs("copyRotation")]
	private bool m_CopyRotation;

	[SerializeField]
	[FormerlySerializedAs("copyPosition")]
	private bool m_CopyPosition;

	public Transform target
	{
		get
		{
			return null;
		}
		set
		{
		}
	}

	public bool copyRotation
	{
		get
		{
			return false;
		}
		set
		{
		}
	}

	public bool copyPosition
	{
		get
		{
			return false;
		}
		set
		{
		}
	}

	private void LateUpdate()
	{
	}
}
