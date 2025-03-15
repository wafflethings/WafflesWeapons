using System;
using System.Collections.Generic;
using SettingsMenu.Components;
using UnityEngine;
using UnityEngine.InputSystem;

public class ControlsOptions : MonoBehaviour
{
	private InputManager inman;

	[HideInInspector]
	public OptionsManager opm;

	public List<ActionDisplayConfig> actionConfig;

	private Dictionary<Guid, ActionDisplayConfig> idConfigDict;

	public Transform actionParent;

	public GameObject actionTemplate;

	public GameObject sectionTemplate;

	private GameObject currentKey;

	public Color normalColor;

	public Color pressedColor;

	private bool canUnpause;

	public SettingsPageBuilder settingsPageBuilder;

	public TooltipManager tooltipManager;

	private List<GameObject> rebindUIObjects;

	public GameObject modalBackground;

	public void ShowModal()
	{
	}

	public void HideModal()
	{
	}

	private void Awake()
	{
	}

	private void OnEnable()
	{
	}

	private void OnDisable()
	{
	}

	public void OnActionChanged(InputAction action)
	{
	}

	public void ResetToDefault()
	{
	}

	private void Rebuild(InputControlScheme controlScheme)
	{
	}

	private void LateUpdate()
	{
	}

	public void ScrollOn(bool stuff)
	{
	}

	public void ScrollVariations(int stuff)
	{
	}

	public void ScrollReverse(bool stuff)
	{
	}
}
