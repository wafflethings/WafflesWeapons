using UnityEngine;
using UnityEngine.Serialization;

// This class has the minimum possible execution order,
// so that it can be overridden by other code reliably.
[DefaultExecutionOrder(int.MinValue)]
public sealed class CopyPositionAndRotation : MonoBehaviour
{
    [SerializeField]
    [FormerlySerializedAs("target")]
    Transform m_Target;

    [SerializeField]
    [FormerlySerializedAs("copyRotation")]
    bool m_CopyRotation = true;

    [SerializeField]
    [FormerlySerializedAs("copyPosition")]
    bool m_CopyPosition = true;

    public Transform target
    {
        get => m_Target;
        set => m_Target = value;
    }

    public bool copyRotation
    {
        get => m_CopyRotation;
        set => m_CopyRotation = value;
    }

    public bool copyPosition
    {
        get => m_CopyPosition;
        set => m_CopyPosition = value;
    }

    void LateUpdate()
    {
        if (m_CopyRotation)
            transform.rotation = m_Target.rotation;

        if (m_CopyPosition)
            transform.position = m_Target.position;
    }
}
