using UnityEngine;
using UnityEngine.Serialization;

 
 
[DefaultExecutionOrder(int.MaxValue)]
public sealed class LateCopyPositionAndRotation : MonoBehaviour
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
{get;set;}
    public bool copyRotation
{get;set;}
    public bool copyPosition
{get;set;}
    void LateUpdate() { }}
