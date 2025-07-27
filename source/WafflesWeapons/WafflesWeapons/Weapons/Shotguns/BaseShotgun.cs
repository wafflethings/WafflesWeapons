using System.Collections.Generic;
using UnityEngine;

namespace WafflesWeapons.Weapons.Shotguns;

public class BaseShotgun : MonoBehaviour
{
    internal static Dictionary<Shotgun, BaseShotgun> VanillaToModded = new();
    
    public ChargeProjectileModule? ChargeProjectileModule;
    
    protected Shotgun _shotgun;
    
    protected virtual void Awake()
    {
        if (!TryGetComponent(out _shotgun) || _shotgun == null)
        {
            Plugin.Log.LogError($"{gameObject.name} lacks Shotgun script - this will not work!!");
            Destroy(this);
            return;
        }
        
        VanillaToModded.Add(_shotgun, this);
    }
    
    private void OnDestroy()
    {
        if (_shotgun != null)
        {
            VanillaToModded.Remove(_shotgun);
        }
    }
}
