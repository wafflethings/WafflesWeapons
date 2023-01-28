using ExtraAlts.Weapons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace ExtraAlts
{
    public class LoaderArmCollisionHandler : MonoSingleton<LoaderArmCollisionHandler>
    {
		public static GameObject NotifyGrounded;

		public bool MidCharge = false;
		public GroundCheck gc;
		public float Charge;
		public List<GameObject> AlrHit = new List<GameObject>();
		public List<Coin> BadCoins = new List<Coin>();
		public int Dashes = 0;

		private void Start()
        {
			gc = FindObjectOfType<GroundCheck>();

		}

		//FromGround = the reset came from touching ground (not from coin)
		public void ResetDash(bool FromGround)
		{
			if (FromGround)
			{
				Dashes = 0;
			} else
            {
				Dashes += 1;
            }

			Instantiate(NotifyGrounded);
			MidCharge = false;
			AlrHit.Clear();
			BadCoins.Clear();
		}

		private void OnTriggerEnter(Collider other)
		{
			/* EnemyIdentifier eiddebug = null;
			if (other.GetComponent<EnemyIdentifier>() != null)
			{
				eiddebug = other.GetComponent<EnemyIdentifier>();
			}
			else if (other.GetComponent<EnemyIdentifierIdentifier>() != null)
			{
				eiddebug = other.GetComponent<EnemyIdentifierIdentifier>().eid;
			}

			Debug.Log($"we just hit {other.gameObject.name} on {other.gameObject.layer}. eid: {eiddebug != null}. tag: {other.gameObject.tag}");
			if(eiddebug != null)
            {
				Debug.Log($"alrhit: {AlrHit.Contains(eiddebug.gameObject)}, MidCharge: {MidCharge}");
            } */

			if (MidCharge && (other.gameObject.layer == 8 || other.gameObject.layer == 24))
			{
				Breakable br;
				if (other.TryGetComponent(out br))
                {
					br.Break();
                }

				if (other.CompareTag("Floor") || other.CompareTag("Moving"))
				{
					var nm = NewMovement.Instance;
					if (nm.rb.velocity.y < -60)
					{
						Instantiate(nm.gc.shockwave, nm.gc.transform.position, Quaternion.identity).GetComponent<PhysicalShockwave>().force *= Charge * 1.5f;
					}
					ResetDash(true);
				}
			}

			if (MidCharge)
			{
				if (other.GetComponent<Coin>() != null)
				{
					var coin = other.GetComponent<Coin>();
					if (!BadCoins.Contains(coin))
					{
						ResetDash(false);
						coin.Punchflection();
					}
				}

				if (other.GetComponent<EnemyIdentifierIdentifier>() != null || other.GetComponent<EnemyIdentifier>() != null)
				{
					EnemyIdentifier eid = null;
					if (!other.GetComponent<EnemyIdentifier>())
					{
						eid = other.GetComponent<EnemyIdentifierIdentifier>().eid;
					}
					else
					{
						eid = other.GetComponent<EnemyIdentifier>();
					}

					if (!eid.dead && !AlrHit.Contains(eid.gameObject))
					{
						Debug.Log("enemy hit?");
						eid.hitter = "punch";
						eid.DeliverDamage(eid.gameObject, NewMovement.Instance.rb.velocity, other.gameObject.transform.position, Charge * 1.1f, false, 0, gameObject);
						if (eid.dead)
						{
							eid.gameObject.AddComponent<Bleeder>().GetHit(eid.gameObject.transform.position, GoreType.Head);
						}
						MonoSingleton<CameraController>.Instance.CameraShake(0.5f);
						MonoSingleton<TimeController>.Instance.HitStop(0.05f);
						AlrHit.Add(eid.gameObject);
					}
				}
			}
		}
	}
}
