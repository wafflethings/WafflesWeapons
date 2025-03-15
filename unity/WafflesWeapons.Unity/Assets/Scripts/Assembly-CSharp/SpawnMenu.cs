using System.Collections.Generic;
using ULTRAKILL.Cheats;
using UnityEngine;

[ConfigureSingleton(SingletonFlags.NoAutoInstance)]
public class SpawnMenu : MonoSingleton<SpawnMenu>
{
	[SerializeField]
	private SpawnMenuSectionReference sectionReference;

	[SerializeField]
	private SpawnableObjectsDatabase objects;

	[HideInInspector]
	public SummonSandboxArm armManager;

	[SerializeField]
	private Sprite lockedIcon;

	private Dictionary<string, Sprite> spriteIcons;

	protected override void Awake()
	{
	}

	protected override void OnDestroy()
	{
	}

	public void RebuildIcons()
	{
	}

	public void ResetMenu()
	{
	}

	public void RebuildMenu()
	{
	}

	private Sprite ResolveSprite(SpawnableObject target)
	{
		return null;
	}

	private void CreateButtons(SpawnableObject[] list, string sectionName)
	{
	}

	private void Update()
	{
	}

	private void OnDisable()
	{
	}

	protected override void OnEnable()
	{
	}

	private void SelectObject(SpawnableObject obj)
	{
	}
}
