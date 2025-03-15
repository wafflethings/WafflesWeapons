using UnityEngine;
using UnityEngine.InputSystem;

public sealed class ScaleVector2DeltaTimeProcessor : InputProcessor<Vector2>
{
	static ScaleVector2DeltaTimeProcessor()
	{
	}

	public override Vector2 Process(Vector2 value, InputControl control)
	{
		return default(Vector2);
	}

	[RuntimeInitializeOnLoadMethod]
	private static void Initialize()
	{
	}
}
