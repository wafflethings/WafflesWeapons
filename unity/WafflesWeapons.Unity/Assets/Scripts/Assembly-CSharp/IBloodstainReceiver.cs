using UnityEngine;

public interface IBloodstainReceiver
{
	bool HandleBloodstainHit(ref RaycastHit hit);
}
