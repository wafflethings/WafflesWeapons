using System.Collections.Generic;

public class EnemyCooldowns : MonoSingleton<EnemyCooldowns>
{
	public float virtueCooldown;

	public float ferrymanCooldown;

	public List<Drone> currentVirtues;

	public List<Ferryman> ferrymen;

	private void Start()
	{
	}

	private void Update()
	{
	}

	private void SlowUpdate()
	{
	}

	public void AddVirtue(Drone drn)
	{
	}

	public void RemoveVirtue(Drone drn)
	{
	}

	public void AddFerryman(Ferryman fm)
	{
	}

	public void RemoveFerryman(Ferryman fm)
	{
	}
}
