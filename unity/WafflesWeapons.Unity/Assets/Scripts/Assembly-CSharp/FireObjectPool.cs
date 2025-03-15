using System.Collections.Generic;
using UnityEngine;

[ConfigureSingleton(SingletonFlags.NoAutoInstance)]
public class FireObjectPool : MonoSingleton<FireObjectPool>
{
	public GameObject firePrefab;

	public GameObject simpleFirePrefab;

	public int poolSize;

	private Queue<GameObject> firePool;

	private Queue<GameObject> simpleFirePool;

	private new void Awake()
	{
	}

	public GameObject GetFire(bool isSimple)
	{
		return null;
	}

	public void ReturnFire(GameObject fireObject, bool isSimple)
	{
	}

	public void RemoveAllFiresFromObject(GameObject objectToSearch)
	{
	}
}
