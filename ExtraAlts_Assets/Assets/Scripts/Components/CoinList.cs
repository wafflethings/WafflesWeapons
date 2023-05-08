using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinList : MonoSingleton<CoinList>
{
	public List<Coin> revolverCoinsList = new List<Coin>();

	public void AddCoin(Coin coin) { }
	public void RemoveCoin(Coin coin) { }
	void Start() { }
	void SlowUpdate() { }}