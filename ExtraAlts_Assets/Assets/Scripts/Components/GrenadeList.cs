using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrenadeList : MonoSingleton<GrenadeList>
{
	public List<Grenade> grenadeList = new List<Grenade>();
	public List<Cannonball> cannonballList = new List<Cannonball>();

	public void AddGrenade(Grenade gren) { }
	public void AddCannonball(Cannonball cb) { }
	public void RemoveGrenade(Grenade gren) { }
	public void RemoveCannonball(Cannonball cb) { }
	void Start() { }
	void SlowUpdate() { }}
