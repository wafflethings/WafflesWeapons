using UnityEngine;

namespace WafflesWeapons.Weapons.Shotguns;

public class BaseShotgun : MonoBehaviour
{
    private Shotgun _shotgun;
    
    protected virtual void Awake()
    {
        if (!TryGetComponent(out _shotgun) || _shotgun == null)
        {
            Plugin.Log.LogError($"{gameObject.name} lacks Shotgun script - this will not work!!");
            Destroy(this);
            return;
        }
    }
}
