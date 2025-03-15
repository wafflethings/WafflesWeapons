using UnityEngine;

[CreateAssetMenu(fileName = "New Fish Database", menuName = "ULTRAKILL/FishDB")]
public class FishDB : ScriptableObject
{
	public string fullName;

	public Color symbolColor;

	public GameObject fishGhostPrefab;

	public FishDescriptor[] foundFishes;

	public void SetupWater(Water water)
	{
	}

	public FishDescriptor GetRandomFish(FishObject[] attractFish)
	{
		return null;
	}
}
