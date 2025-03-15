using System;
using System.Runtime.CompilerServices;
using UnityEngine;

public class ShopButton : MonoBehaviour
{
	public bool deactivated;

	public bool failure;

	public GameObject clickSound;

	public GameObject failSound;

	public GameObject[] toActivate;

	public GameObject[] toDeactivate;

	public VariationInfo variationInfo;

	private ControllerPointer pointer;

	public event Action PointerClickSuccess
	{
		[CompilerGenerated]
		add
		{
		}
		[CompilerGenerated]
		remove
		{
		}
	}

	public event Action PointerClickFailure
	{
		[CompilerGenerated]
		add
		{
		}
		[CompilerGenerated]
		remove
		{
		}
	}

	public event Action PointerClickDeactivated
	{
		[CompilerGenerated]
		add
		{
		}
		[CompilerGenerated]
		remove
		{
		}
	}

	private void Awake()
	{
	}

	private void OnPointerClick()
	{
	}
}
