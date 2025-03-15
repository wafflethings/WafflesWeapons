using System.Collections.Generic;
using UnityEngine;

[ConfigureSingleton(SingletonFlags.NoAutoInstance)]
public class WeaponWheel : MonoSingleton<WeaponWheel>
{
	private List<WheelSegment> segments;

	public int segmentCount;

	public GameObject clickSound;

	public GameObject background;

	private int selectedSegment;

	private int lastSelectedSegment;

	private Vector2 direction;

	private void Start()
	{
	}

	private new void OnEnable()
	{
	}

	private void OnDisable()
	{
	}

	private void Update()
	{
	}

	public void Show()
	{
	}

	public void SetSegments(WeaponDescriptor[] weaponDescriptors, int[] slotIndexes)
	{
	}
}
