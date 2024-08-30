using AtlasLib.Utils;
using UnityEngine;
using UnityEngine.UI;
using WafflesWeapons.Components;

namespace WafflesWeapons.Weapons.Desperado;

public class DesperadoBehaviour : GunBehaviour<DesperadoBehaviour>
{
    private Revolver rev;
    private float currentSlider = 0;
    private float leftLimit = 0.4f;
    private float rightLimit = 0.6f;

    private float size = 0.35f;
    [Header("Bar Size")]
    public float minSize = 0.025f;
    public float maxSize = 0.35f;
    public float sizeGainRate = 0.03f;
    public float perfectSizeDecrease = 0.1f;

    private float sliderSpeed = 1.5f;
    [Header("Bar Speed")]
    public float maxSpeed = 5;
    public float minSpeed = 1.5f;
    public float speedDecayRate = 0.5f;
    public float PerfectIncrease = 0.75f;
    public float BadIncrease = 1f;

    private bool goingRight = true;
    [HideInInspector] public bool shouldMove = false;
    private bool shouldAdd = false;
    private float toAdd = 0;

    [Header("Beams")]
    public GameObject PerfectBeam;
    public float PerfectDamage = 2.5f;
    public float PerfectStepDecrease = 0.5f;
    public float PerfectCurrentDamage;

    public GameObject BadBeam;

    [Header("Sliders")]
    public AudioSource SoundEffect;
    public Slider slider;
    public Slider left;
    public Slider right;
    public RectTransform perfectBar;

    public void Start()
    {
        rev = GetComponent<Revolver>();
        Desperado.Guns.Add(this);
    }

    public void OnEnable()
    {
        RandomizeBar();
    }

    public void OnDestroy()
    {
        Desperado.Guns.Remove(this);
    }

    public void Charge()
    {
        if (!rev.shootReady)
        {
            if (rev.shootCharge + 200f * Time.deltaTime < 100f)
            {
                rev.shootCharge += 200f * Time.deltaTime;
            }
            else
            {
                rev.shootCharge = 100f;
                rev.shootReady = true;
            }
        }

        size = Mathf.Clamp(size, minSize, maxSize);
        sliderSpeed = Mathf.Clamp(sliderSpeed, minSpeed, maxSpeed);

        if (shouldMove)
        {
            if (!SoundEffect.isPlaying)
            {
                SoundEffect.Play();
            }
            SoundEffect.pitch = 1 - GetProximityToBar();
            if (SoundEffect.pitch == 1)
            {
                SoundEffect.pitch = 2;
            }

            if (goingRight)
            {
                currentSlider += sliderSpeed * Time.deltaTime;
            }
            else
            {
                currentSlider -= sliderSpeed * Time.deltaTime;
            }

            if ((currentSlider > 1 && goingRight) || (currentSlider < 0 && !goingRight))
            {
                goingRight = !goingRight;
                RandomizeBar();

                if (shouldAdd)
                {
                    sliderSpeed += toAdd;
                    toAdd = 0;
                    shouldAdd = false;
                }

                if (currentSlider > 1)
                {
                    currentSlider = 1;
                }
                if (currentSlider < 0)
                {
                    currentSlider = 0;
                }

                shouldMove = Inputs.AltFireHeld && gameObject.activeInHierarchy;
            }
        }
        else
        {
            if (SoundEffect.isPlaying)
            {
                SoundEffect.Stop();
            }

            sliderSpeed += toAdd;
            toAdd = 0;
            sliderSpeed -= speedDecayRate * Time.deltaTime;
            size += sizeGainRate * Time.deltaTime;
            shouldMove = Inputs.AltFireHeld && gameObject.activeInHierarchy;
        }
    }

    public void Update()
    {
        rev.pierceShotCharge = 0;
            
        if (rev.gc.activated)
        {
            Charge();
            slider.value = currentSlider;

            if (rev.shootReady && rev.gunReady)
            {
                if (Inputs.FireHeld)
                {
                    if ((rev.altVersion && WeaponCharges.Instance.revaltpickupcharges[rev.gunVariation] == 0) || !rev.altVersion)
                    {
                        Debug.Log($"Just shot: {leftLimit} < {currentSlider} < {rightLimit}");
                        shouldAdd = true;

                        if (currentSlider > leftLimit && currentSlider <= rightLimit) 
                        {
                            TimeController.Instance.SlowDown(0.25f);
                            rev.revolverBeam = PerfectBeam;
                            PerfectCurrentDamage = PerfectDamage;
                            toAdd = PerfectIncrease;
                            size -= perfectSizeDecrease;
                        }
                        else
                        {
                            rev.revolverBeam = BadBeam;
                            toAdd = BadIncrease;
                        }
                        rev.Shoot();
                    }
                }
            }
        }
    }

    public void RandomizeBar()
    {
        if (goingRight)
        {
            leftLimit = UnityEngine.Random.Range(0.5f, 0.95f - size);
        }
        else
        {
            leftLimit = UnityEngine.Random.Range(0.05f, 0.5f - size);
        }            

        rightLimit = leftLimit + size;
        perfectBar.anchoredPosition = new Vector2(leftLimit * 200, 0);
        perfectBar.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, size * 200);
        left.value = leftLimit;
        right.value = rightLimit;
    }

    public float GetProximityToBar()
    {
        if (currentSlider > leftLimit && currentSlider < rightLimit)
        {
            return 0;
        }

        float closest = Mathf.Abs(currentSlider - leftLimit) < Mathf.Abs(currentSlider - rightLimit) ? leftLimit : rightLimit;
        return Mathf.Abs(currentSlider - closest);
    }
}