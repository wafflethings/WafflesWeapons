using System.Collections.Generic;

public class CheckPointsController : MonoSingleton<CheckPointsController>
{
	private int requests;

	public List<CheckPoint> cps;

	private List<ShopZone> shops;

	public void DisableCheckpoints()
	{
	}

	public void EnableCheckpoints()
	{
	}

	public void AddCheckpoint(CheckPoint cp)
	{
	}

	public void RemoveCheckpoint(CheckPoint cp)
	{
	}

	public void AddShop(ShopZone shop)
	{
	}

	public void RemoveShop(ShopZone shop)
	{
	}
}
