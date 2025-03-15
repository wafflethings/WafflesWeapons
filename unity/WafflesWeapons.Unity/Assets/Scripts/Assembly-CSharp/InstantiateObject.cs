using System.Collections.Generic;
using UnityEngine;

public class InstantiateObject : MonoBehaviour
{
	[SerializeField]
	private bool instantiateOnEnable;

	[SerializeField]
	private GameObject source;

	[SerializeField]
	private InstantiateObjectMode mode;

	[SerializeField]
	private bool removePreviousOnInstantiate;

	[SerializeField]
	private bool reParent;

	[SerializeField]
	private bool useOwnPosition;

	[SerializeField]
	private bool useOwnRotation;

	[SerializeField]
	private bool combineRotations;

	[SerializeField]
	private bool parentToGoreZone;

	private GoreZone gz;

	private List<GameObject> createdObjects;

	private void OnEnable()
	{
	}

	public void Instantiate()
	{
	}
}
