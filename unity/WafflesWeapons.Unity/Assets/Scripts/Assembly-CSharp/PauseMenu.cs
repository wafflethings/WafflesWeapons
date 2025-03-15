using TMPro;
using UnityEngine;
using UnityEngine.UI;
using plog;

public class PauseMenu : MonoBehaviour
{
	private static readonly plog.Logger Log;

	[SerializeField]
	private Button checkpointButton;

	[SerializeField]
	private TMP_Text checkpointText;

	private bool nonStandardCheckpointButton;

	private void OnEnable()
	{
	}

	private void OnCheckpointButton()
	{
	}
}
