using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VariationInfo : MonoBehaviour
{
    public GameObject varPage;
    public Text moneyText;
    public int cost;
    public Text costText;

    public ShopButton buyButton;
    public GameObject buySound;

    public Button equipButton;
    public Sprite[] equipSprites;

    public bool alreadyOwned;
    public string weaponName;
    public GameObject orderButtons;

    public void UpdateMoney()
{}
    public void WeaponBought()
{}
    /*public void EquipWeapon()
    {
        if (PlayerPrefs.GetInt(weaponName, 0) > 0)
        {
            equipImage.SetActive(false);
            PlayerPrefs.SetInt(weaponName, 0);
        }
        else
        {
            equipImage.SetActive(true);
            PlayerPrefs.SetInt(weaponName, 1);
        }

        if (gs == null)
            gs = player.GetComponentInChildren<GunSetter>();

        gs.ResetWeapons();

        if (fc == null)
            fc = player.GetComponentInChildren<FistControl>();

        fc.ResetFists();
    }*/

    public void ChangeEquipment(int value)
{}}
