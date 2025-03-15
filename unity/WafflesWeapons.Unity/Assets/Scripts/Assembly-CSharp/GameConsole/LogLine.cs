using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace GameConsole
{
	public class LogLine : MonoBehaviour
	{
		[SerializeField]
		private TMP_Text timestamp;

		[SerializeField]
		private TMP_Text message;

		[SerializeField]
		private TMP_Text context;

		[SerializeField]
		private Image contextPanel;

		[SerializeField]
		private Image mainPanel;

		[Space]
		[SerializeField]
		private CanvasGroup attentionFlashGroup;

		[Space]
		[SerializeField]
		private Color normalLogColor;

		[SerializeField]
		private Color warningLogColor;

		[SerializeField]
		private Color errorLogColor;

		[SerializeField]
		private Color cliLogColor;

		[Space]
		[SerializeField]
		private float normalHeight;

		[SerializeField]
		private float expandedHeight;

		private RectTransform rectTransform;

		private Vector2? defaultTextOffsetMin;

		private Vector2? defaultTextOffsetMax;

		private Vector2? defaultTextSizeDelta;

		private ConsoleLog log;

		private void Awake()
		{
		}

		public void Wipe()
		{
		}

		public void PopulateLine(ConsoleLog capture)
		{
		}

		public void ToggleExpand()
		{
		}

		private void RefreshSize()
		{
		}

		private void Update()
		{
		}

		private float TimeSinceToFlashAlpha(float timeSinceLogged)
		{
			return 0f;
		}
	}
}
