using UnityEngine;

public class CyberGrindNavHelper : MonoBehaviour
{
	private enum BridgeDirection
	{
		Left = 0,
		Right = 1,
		Top = 2,
		Bottom = 3
	}

	private struct BridgeBlock
	{
		public bool TopBridge;

		public bool BottomBridge;

		public bool LeftBridge;

		public bool RightBridge;
	}

	private BridgeBlock[][] bridges;

	public void ResetLinks()
	{
	}

	public void GenerateLinks(EndlessCube[][] cbs)
	{
	}

	private void CheckNeighbors(EndlessCube[][] cbs, int x, int y)
	{
	}

	private void CheckIfBridge(EndlessCube dom, EndlessCube mid, EndlessCube sub, BridgeDirection dir)
	{
	}

	private void CheckNeighbors(EndlessCube dom, EndlessCube sub)
	{
	}

	private void CheckNeighbors(Transform dom, Transform sub)
	{
	}
}
