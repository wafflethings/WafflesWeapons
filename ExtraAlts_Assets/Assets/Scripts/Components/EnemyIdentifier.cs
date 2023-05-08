using System;
using System.Collections.Generic;
using Sandbox;
using UnityEngine;
using UnityEngine.Events;

public enum EnemyClass
{
	Husk,
	Machine,
	Demon,
	Divine,
	Other
};

public enum EnemyType
{
	 

	CancerousRodent = 23,
	Cerberus = 0,
	Drone = 1,
	Ferryman = 26,
	Filth = 3,
	FleshPanopticon = 30,
	FleshPrison = 17,
	Gabriel = 16,
	GabrielSecond = 28,
	HideousMass = 2,
	Idol = 21,
	Leviathan = 27,
	MaliciousFace = 4,
	Mandalore = 25,
	Mindflayer = 5,
	Minos = 11,
	MinosPrime = 18,
	Schism = 14,
	Sisyphus = 19,
	SisyphusPrime = 29,
	Soldier = 15,
	Stalker = 12,
	Stray = 13,
	Streetcleaner = 6,
	Swordsmachine = 7,
	Turret = 20,
	V2 = 8,
	V2Second = 22,
	VeryCancerousRodent = 24,
	Virtue = 9,
	Wicked = 10,
}

public enum HitterAttribute
{
	None,
	Fire,
	Electricity,
	Antidivine,
	HeavyKnockback
}

public class EnemyIdentifier : MonoBehaviour, IAlter, IAlterOptions<bool>
{

	public EnemyClass enemyClass;
	public EnemyType enemyType;
	public bool spawnIn;
	public GameObject spawnEffect;
	public float health;
	public string[] weaknesses;
	public float[] weaknessMultipliers;
	public float totalDamageTakenMultiplier = 1;
	public GameObject weakPoint;
	 
	public bool dead;
	public bool ignoredByEnemies;
	public bool useBrakes;
	public bool bigEnemy;
	public bool unbounceable;
	public bool poise;
	public bool flying;

	public bool dontCountAsKills;
	public bool dontUnlockBestiary;
	public bool specialOob;
	public GameObject[] activateOnDeath;
	public UnityEvent onDeath;
	public int difficultyOverride = -1;

	[Header("Modifiers")]
	public bool hookIgnore;
	public bool sandified;
	public bool blessed;
	public float radianceTier = 1;
	public bool healthBuff;
	public float healthBuffModifier = 1.5f;
	public bool speedBuff;
	public float speedBuffModifier = 1.5f;
	public bool damageBuff;
	public float damageBuffModifier = 1.5f;

	[Space(10)]
	public List<Renderer> buffUnaffectedRenderers = new List<Renderer>();
	[SerializeField] private string overrideFullName;

	public void ForceGetHealth() { }
	private void Start() { }
	private void Update() { }
	void UpdateModifiers() { }
	void CheckBurners() { }
	public void DeliverDamage(GameObject target, Vector3 force, Vector3 hitPoint, float multiplier, bool tryForExplode, float critMultiplier = 0, GameObject sourceWeapon = null) { }
	public void Death() { }
	public void DestroyMagnets(){}
	public void InstaKill() { }
	public void Explode() { }
	public void Splatter() { }
	public void StopSplatter() { }
	public void Sandify(bool ignorePrevious = false) { }
	public void Desandify(bool visualOnly = false) { }
	public void Bless(bool ignorePrevious = false) { }
	public void Unbless(bool visualOnly = false) { }
	public void BuffAll() { }
	public void UnbuffAll() { }
	public void DamageBuff(float modifier = 1.5f) { }
	public void DamageUnbuff() { }
	public void SpeedBuff(float modifier = 1.5f) { }
	public void SpeedUnbuff() { }
	public void HealthBuff(float modifier = 1.5f) { }
	public void HealthUnbuff() { }
	public void UpdateBuffs(bool visualsOnly = false) { }
	public void ChangeDamageTakenMultiplier(float newMultiplier) { }
	public void SimpleDamage(float amount) { }
	public void SimpleDamageIgnoreMultiplier(float amount) { }
	public string fullName {get;set;}	public string alterKey {get;set;}	public string alterCategoryName {get;set;}	public bool allowOnlyOne {get;set;}
	public AlterOption<bool>[] options {get;set;}}
