[ConfigureSingleton(SingletonFlags.DestroyDuplicates)]
public class ChallengeDoneByDefault : MonoSingleton<ChallengeDoneByDefault>
{
	private bool prepared;

	private void Start()
	{
	}

	public void Prepare()
	{
	}
}
