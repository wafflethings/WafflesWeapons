using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace WafflesWeapons;

public class CustomColour : MonoBehaviour
{
    public ExtendedWeaponVariant variationColorReal;
}

public enum ExtendedWeaponVariant
{
    BlueVariant,
    GreenVariant,
    RedVariant,
    GoldVariant,
    DarkBlueVariant,
    OrangeVariant,
    PurpleVariant
}