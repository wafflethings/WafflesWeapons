[ConfigureSingleton(SingletonFlags.NoAutoInstance)]
public class OnLevelStart : MonoSingleton<OnLevelStart>
{
	public UltrakillEvent onStart;

	private bool activated;

	public bool hideFogUntilStart;

	private bool fogHidden;

	public bool levelNameOnStart;

	protected override void Awake()
	{
	}

	public void StartLevel(bool startTimer = true, bool startMusic = true)
	{
	}
}
