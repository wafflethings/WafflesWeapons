using AtlasLib.Weapons;
using UnityEngine;
using WafflesWeapons.Assets;

namespace WafflesWeapons.Weapons.Conductor;

public class Conductor : Weapon
{
    public static WeaponAssets Assets;
        
    public static GameObject FullyChargedExplosion;
    public static GameObject SawExplosion;
    public static GameObject ShotProjectileExplosion;
    public static GameObject RocketExplosion;
    public static GameObject MagnetZap;
    public static GameObject MagnetZapEffect;
        
    static Conductor()
    {
        Assets = AddressableManager.Load<WeaponAssets>("Assets/ExtraAlts/Conductor/Conductor Assets.asset");
        FullyChargedExplosion = Assets.GetAsset<GameObject>("FullyChargedExplosion");
        SawExplosion = Assets.GetAsset<GameObject>("SawExplosion");
        ShotProjectileExplosion = Assets.GetAsset<GameObject>("ShotProjectileExplosion");
        RocketExplosion = Assets.GetAsset<GameObject>("RocketExplosion");
        MagnetZap = Assets.GetAsset<GameObject>("MagnetZap");
        MagnetZapEffect = Assets.GetAsset<GameObject>("MagnetZapEffect");
    }

    public override WeaponInfo Info => Assets.GetAsset<WeaponInfo>("Info");
}