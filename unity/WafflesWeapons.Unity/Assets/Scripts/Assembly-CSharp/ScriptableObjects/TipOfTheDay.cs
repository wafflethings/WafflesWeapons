using UnityEngine;

namespace ScriptableObjects
{
	[CreateAssetMenu(fileName = "TipOfTheDay", menuName = "ULTRAKILL/TipOfTheDay")]
	public class TipOfTheDay : ScriptableObject
	{
		[TextArea(2, 8)]
		public string tip;
	}
}
