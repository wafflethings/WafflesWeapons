[ConfigureSingleton(SingletonFlags.NoAutoInstance)]
public class InputManager : MonoSingleton<InputManager>
{
    public bool ScrOn;
    public bool ScrWep;
    public bool ScrVar;
    public bool ScrRev;

    public void UpdateBindings() {}
}
