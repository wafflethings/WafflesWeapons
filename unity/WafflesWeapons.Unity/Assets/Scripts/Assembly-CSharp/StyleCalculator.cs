using TMPro;
using UnityEngine;

[ConfigureSingleton(SingletonFlags.NoAutoInstance)]
public class StyleCalculator : MonoSingleton<StyleCalculator>
{
	public StyleHUD shud;

	private GameObject player;

	private NewMovement nmov;

	public TMP_Text airTimeText;

	public float airTime;

	private Vector3 airTimePos;

	private StatsManager sman;

	private GunControl gc;

	public bool enemiesShot;

	public float multikillTimer;

	public int multikillCount;

	private string maxAirTime;

	private float lastAirTime;

	private void Start()
	{
	}

	private void Update()
	{
	}

	public void HitCalculator(string hitter, string enemyType, string hitLimb, bool dead, EnemyIdentifier eid = null, GameObject sourceWeapon = null)
	{
	}

	public void AddToMultiKill(GameObject sourceWeapon = null)
	{
	}

	private void AddPoints(int points, string pointName, EnemyIdentifier eid, GameObject sourceWeapon = null)
	{
	}
}
