using System;
using Train;
using UnityEngine;
using UnityEngine.UI;

public class TramControl : MonoBehaviour
{    private void Awake()
    {
        if (this.targetTram)
        {
            this.targetTram.controller = this;
        }
    }
    public void SpeedUp()
    {
        if (this.SpeedUp(1))
        {
            if (this.clickSound)
            {
                Instantiate<GameObject>(this.clickSound, base.transform.position, Quaternion.identity, base.transform);
                return;
            }
        }
        else if (this.clickFailSound)
        {
            Instantiate<GameObject>(this.clickFailSound, base.transform.position, Quaternion.identity, base.transform);
        }
    }
    public void SpeedDown()
    {
        if (this.SpeedDown(1))
        {
            if (this.clickSound)
            {
                Instantiate<GameObject>(this.clickDownSound, base.transform.position, Quaternion.identity, base.transform);
                return;
            }
        }
        else if (this.clickFailSound)
        {
            Instantiate<GameObject>(this.clickFailSound, base.transform.position, Quaternion.identity, base.transform);
        }
    }
    public bool SpeedUp(int amount)
    {
        if (!this.targetTram.poweredOn)
        {
            return false;
        }
        if (this.targetTram.currentPoint != null && this.targetTram.currentPoint.GetDestination(true) == null)
        {
            return false;
        }
        if (this.zapAmount > 0f)
        {
            this.currentSpeedStep = this.maxSpeedStep;
        }
        else if (this.currentSpeedStep < this.maxSpeedStep)
        {
            if (this.currentSpeedStep + amount <= this.maxSpeedStep)
            {
                this.currentSpeedStep += amount;
            }
            else
            {
                this.currentSpeedStep = this.maxSpeedStep;
            }
            return true;
        }
        return false;
    }
    public bool SpeedDown(int amount)
    {
        if (!this.targetTram.poweredOn)
        {
            return false;
        }
        if (this.targetTram.currentPoint != null && this.targetTram.currentPoint.GetDestination(false) == null)
        {
            return false;
        }
        if (this.zapAmount > 0f)
        {
            this.currentSpeedStep = this.minSpeedStep;
        }
        else if (this.currentSpeedStep > this.minSpeedStep)
        {
            if (this.currentSpeedStep - amount >= this.minSpeedStep)
            {
                this.currentSpeedStep -= amount;
            }
            else
            {
                this.currentSpeedStep = this.minSpeedStep;
            }
            return true;
        }
        return false;
    }
    private void LateUpdate()
    {
        if (this.targetTram == null || !base.enabled || !base.gameObject.activeInHierarchy)
        {
            return;
        }
        if (this.zapAmount > 0f)
        {
            this.zapAmount = Mathf.MoveTowards(this.zapAmount, 0f, Time.deltaTime);
            this.targetTram.zapAmount = this.zapAmount;
            if (this.currentSpeedStep != 0)
            {
                this.currentSpeedStep = ((this.currentSpeedStep > 0) ? this.maxSpeedStep : this.minSpeedStep);
            }
            this.targetTram.speed = (float)this.currentSpeedStep * (this.speedMultiplier / 10f);
        }
        else
        {
            this.targetTram.speed = Mathf.MoveTowards(this.targetTram.speed, (float)this.currentSpeedStep * (this.speedMultiplier / 10f), this.speedMultiplier / 10f * Time.deltaTime);
        }
        this.UpdateZapEffects();
        if (this.currentSpeedStep != 0)
        {
            if (!this.targetTram.poweredOn)
            {
                this.currentSpeedStep = 0;
            }
            else if (this.targetTram.movementDirection == TramMovementDirection.Forward && !this.targetTram.canGoForward)
            {
                this.currentSpeedStep = 0;
                this.targetTram.speed = 0f;
            }
            else if (this.targetTram.movementDirection == TramMovementDirection.Backward && !this.targetTram.canGoBackward)
            {
                this.currentSpeedStep = 0;
                this.targetTram.speed = 0f;
            }
        }
        if (this.lastSpeedStep != this.currentSpeedStep)
        {
            this.lastSpeedStep = this.currentSpeedStep;
            this.UpdateSpeedIndicators();
        }
    }
    private void FixedUpdate()
    {
    }
    private void UpdateSpeedIndicators()
    {
        for (int i = 0; i < this.speedIndicators.Length; i++)
        {
            this.speedIndicators[i].color = ((i == this.currentSpeedStep - this.minSpeedStep) ? this.speedOnColor : this.speedOffColor);
        }
    }
    public void Zap()
    {
        this.zapAmount = 5f;
        this.targetTram.zapAmount = this.zapAmount;
        this.UpdateZapEffects();
    }
    private void UpdateZapEffects()
    {
        if (this.zapAmount > 0f && !this.zapEffects.activeSelf)
        {
            this.zapEffects.SetActive(true);
        }
        else if (this.zapAmount <= 0f && this.zapEffects.activeSelf)
        {
            this.zapEffects.SetActive(false);
        }
        this.zapLight.intensity = Mathf.Lerp(0f, 10f, this.zapAmount);
        this.zapSprite.color = new Color(this.zapSprite.color.r, this.zapSprite.color.g, this.zapSprite.color.b, Mathf.Lerp(0f, 1f, this.zapAmount));
        this.zapSound.volume = Mathf.Lerp(0f, 0.5f, this.zapAmount);
        this.zapSound.pitch = Mathf.Lerp(0f, 1f, this.zapAmount);
    }
    [SerializeField]
    private Tram targetTram;
    [Space]
    [SerializeField]
    private GameObject clickSound;
    [SerializeField]
    private GameObject clickDownSound;
    [SerializeField]
    private GameObject clickFailSound;
    [Space]
    [SerializeField]
    private int maxSpeedStep;
    [SerializeField]
    private int minSpeedStep;
    [SerializeField]
    private float speedMultiplier;
    [HideInInspector]
    public float zapAmount;
    [SerializeField]
    private Image[] speedIndicators;
    public Color speedOffColor;
    public Color speedOnColor;
    public float maxPlayerDistance = 15f;
    public int currentSpeedStep;
    private int lastSpeedStep;
    [SerializeField]
    private GameObject zapEffects;
    [SerializeField]
    private Light zapLight;
    [SerializeField]
    private SpriteRenderer zapSprite;
    [SerializeField]
    private AudioSource zapSound;
}
