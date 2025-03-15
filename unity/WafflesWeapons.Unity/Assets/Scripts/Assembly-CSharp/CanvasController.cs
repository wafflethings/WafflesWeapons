[ConfigureSingleton(SingletonFlags.NoAutoInstance)]
public class CanvasController : MonoSingleton<CanvasController>
{
	public Crosshair crosshair { get; private set; }

	protected override void Awake()
	{
	}

	protected override void OnEnable()
	{
	}
}
