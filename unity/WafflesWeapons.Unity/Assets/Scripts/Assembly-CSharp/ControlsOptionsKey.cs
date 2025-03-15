using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class ControlsOptionsKey : MonoBehaviour, ISelectHandler, IEventSystemHandler, IDeselectHandler
{
	public TextMeshProUGUI actionText;

	public Button restoreDefaultsButton;

	public GameObject bindingButtonTemplate;

	public Transform bindingButtonParent;

	public Selectable selectable;

	public GameObject blocker;

	private List<Button> bindingButtons;

	private bool selected;

	private readonly Color faintTextColor;

	public void OnSelect(BaseEventData eventData)
	{
	}

	public void OnDeselect(BaseEventData eventData)
	{
	}

	private void SubmitPressed(InputAction.CallbackContext ctx)
	{
	}

	private void OnEnable()
	{
	}

	private void OnDisable()
	{
	}

	private void Update()
	{
	}

	public void RebuildBindings(InputAction action, InputControlScheme controlScheme)
	{
	}

	private (Button, TextMeshProUGUI, Image) BuildNewBindButton()
	{
		return default((Button, TextMeshProUGUI, Image));
	}

	private string GenerateTooltip(InputAction action, InputBinding binding, InputBinding[] conflicts)
	{
		return null;
	}

	private (Button, TextMeshProUGUI, Image, TooltipOnHover) BuildBindingButton(string text)
	{
		return default((Button, TextMeshProUGUI, Image, TooltipOnHover));
	}
}
