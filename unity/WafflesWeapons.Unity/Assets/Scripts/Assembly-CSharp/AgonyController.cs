using UnityEngine;

[ConfigureSingleton(SingletonFlags.NoAutoInstance)]
public class AgonyController : MonoSingleton<AgonyController>
{
	[SerializeField]
	private GameObject reloadPrompt;
}
