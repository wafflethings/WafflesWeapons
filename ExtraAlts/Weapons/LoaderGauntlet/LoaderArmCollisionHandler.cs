using System.Collections.Generic;
using UnityEngine;

namespace WafflesWeapons.Weapons.LoaderGauntlet
{
    public class LoaderArmCollisionHandler : MonoSingleton<LoaderArmCollisionHandler>
    {
        public static GameObject NotifyGrounded;

        public bool CanCharge = true;
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
            Weapons.LoaderGauntlet.curOne.anim.SetBool("Midflight", false);

            if (FromGround)
            {
                Dashes = 0;
                MidCharge = false;
            }
            else
            {
                Dashes += 1;
            }

            Instantiate(NotifyGrounded);
            CanCharge = true;
            AlrHit.Clear();
        }

        private void OnTriggerEnter(Collider other)
        {
            if (MidCharge)
            {
                Breakable br;
                if (other.TryGetComponent(out br))
                {
                    br.Break();
                    return;
                }

                Glass gl;
                if (other.TryGetComponent(out gl))
                {
                    gl.Shatter();
                    return;
                }
            }


            if (other.gameObject.layer == 8 || other.gameObject.layer == 24)
            {
                if (other.CompareTag("Floor") || other.CompareTag("Moving"))
                {
                    if (CanCharge)
                    {
                        MidCharge = false;
                    }
                    if (!CanCharge)
                    {
                        var nm = NewMovement.Instance;
                        if (nm.rb.velocity.y < -40)
                        {
                            GameObject wave = Instantiate(nm.gc.shockwave, nm.gc.transform.position, Quaternion.identity);
                            wave.GetComponent<PhysicalShockwave>().force *= Charge * 0.75f;
                            wave.GetComponent<PhysicalShockwave>().maxSize *= (Charge / 2);
                            wave.transform.localScale = new Vector3(wave.transform.localScale.x, wave.transform.localScale.y, wave.transform.localScale.z);
                        }
                        ResetDash(true);
                    }
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
                        TimeController.Instance.ParryFlash();
                    }
                }

                if (other.GetComponent<EnemyIdentifierIdentifier>() != null || other.GetComponent<EnemyIdentifier>() != null)
                {
                    EnemyIdentifier eid;
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
                        Debug.Log($"{NewMovement.Instance.rb.velocity.magnitude} from charge {Charge}: damage {NewMovement.Instance.rb.velocity.magnitude * 0.075f}");
                        eid.hitter = "heavypunch";
                        eid.DeliverDamage(eid.gameObject, NewMovement.Instance.rb.velocity, other.gameObject.transform.position, NewMovement.Instance.rb.velocity.magnitude * 0.075f, false, 0, gameObject);
                        if (eid.dead)
                        {
                            eid.gameObject.AddComponent<Bleeder>().GetHit(eid.gameObject.transform.position, GoreType.Head);
                            ResetDash(false);
                        }
                        else 
                        {
                            NewMovement.Instance.ForceAddAntiHP((int)(NewMovement.Instance.rb.velocity.magnitude * 0.5f), false, true);
                        }
                        CameraController.Instance.CameraShake(0.5f);
                        TimeController.Instance.HitStop(0.05f);
                        AlrHit.Add(eid.gameObject);
                    }
                }
            }
        }
    }
}
