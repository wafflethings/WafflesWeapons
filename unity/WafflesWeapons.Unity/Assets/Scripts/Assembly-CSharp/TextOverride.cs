using UnityEngine;

internal sealed class TextOverride : MonoBehaviour
{
	private Component m_TextComponent;

	[TextArea]
	[SerializeField]
	private string m_KeyboardText;

	[TextArea]
	[SerializeField]
	private string m_GenericText;

	[TextArea]
	[SerializeField]
	private string m_DualShockText;

	private void Awake()
	{
	}

	private void Update()
	{
	}

	private void SetText(string value)
	{
	}

	private string GetText()
	{
		return null;
	}
}
