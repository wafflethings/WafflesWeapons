using System.Collections;
using UnityEngine;

public class DebugArm : MonoBehaviour
{
    [SerializeField] private LayerMask raycastLayers;
    [SerializeField] private Transform holder;
    [SerializeField] private Animator armAnimator;
    [SerializeField] private AudioSource jabSound;
    [SerializeField] private AudioSource selectSound;
    public static GoreZone debugZone;

    public void PreviewObject(SpawnableObject obj)
{}
    public void ActiveStart()
{}
    public void ActiveEnd()
{}
    public void ReadyToPunch()
{}
    public void PunchEnd()
{}}
