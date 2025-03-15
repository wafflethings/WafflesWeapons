using ScriptableObjects;
using UnityEngine;

[ConfigureSingleton(SingletonFlags.NoAutoInstance)]
public class DefaultReferenceManager : MonoSingleton<DefaultReferenceManager>
{
	public GameObject wetParticle;

	public GameObject sandDrip;

	public GameObject blessingGlow;

	public GameObject sandificationEffect;

	public GameObject enrageEffect;

	public GameObject ineffectiveSound;

	public GameObject continuousSplash;

	public GameObject splash;

	public GameObject smallSplash;

	public GameObject bubbles;

	public GameObject projectile;

	public GameObject projectileExplosive;

	public GameObject parryableFlash;

	public GameObject unparryableFlash;

	public GameObject explosion;

	public GameObject superExplosion;

	public Material puppetMaterial;

	public GameObject puppetSpawn;

	public Material blankMaterial;

	public GameObject madnessEffect;

	public LineRenderer electricLine;

	public GameObject zapImpactParticle;

	public FootstepSet footstepSet;

	public GameObject radianceEffect;

	public Shader masterShader;
}
