using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SliderReleaseColor : MonoBehaviour, IPointerUpHandler, IEventSystemHandler
{
	[SerializeField]
	private Color releaseColor;

	private Color defaultColor;

	private Selectable slider;

	private float fade;

	private void Awake()
	{
	}

	public void OnPointerUp(PointerEventData eventData)
	{
	}

	private void Update()
	{
	}
}
