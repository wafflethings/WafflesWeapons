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

     
    void Start() { }
    private void OnEnable() { }
    public void UpdateMoney() { }
    public void WeaponBought() { }
     

    public void ChangeEquipment(int value) { }}
