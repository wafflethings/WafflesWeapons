using UnityEngine;

[ConfigureSingleton(SingletonFlags.NoAutoInstance)]
public class SandboxSaveConfirmation : MonoSingleton<SandboxSaveConfirmation>
{
	[SerializeField]
	private GameObject saveConfirmationDialog;

	[SerializeField]
	private GameObject blocker;

	public void ConfirmSave()
	{
	}

	public void DisplayDialog()
	{
	}
}
