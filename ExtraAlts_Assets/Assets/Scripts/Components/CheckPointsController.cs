using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPointsController : MonoSingleton<CheckPointsController>
{
    public List<CheckPoint> cps = new List<CheckPoint>();

    public void DisableCheckpoints() { }
    public void EnableCheckpoints() { }
    public void AddCheckpoint(CheckPoint cp) { }
    public void RemoveCheckpoint(CheckPoint cp) { }
    public void AddShop(ShopZone shop) { }
    public void RemoveShop(ShopZone shop) { }}
