using UnityEngine;

public class KeepInBounds : MonoBehaviour
{
    [SerializeField] private bool useColliderCenter;
    [SerializeField] private float maxConsideredDistance;
    [SerializeField] private UpdateMode updateMode = UpdateMode.Update;

    private Vector3 CurrentPosition {get;set;}
    private void Update() { }
    private void FixedUpdate() { }
    private void LateUpdate() { }    
    public void ForceApproveNewPosition() { }
    public void ValidateMove() { }
    [System.Serializable]
    private enum UpdateMode
    {
        None,
        Update,
        FixedUpdate,
        LateUpdate
    }
}