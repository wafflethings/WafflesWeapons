using AtlasLib.Utils;
using UnityEngine;
using WafflesWeapons.Components;

namespace WafflesWeapons.Weapons.DrillRocket;

public class DrillRocketBehaviour : GunBehaviour<DrillRocketBehaviour>
{
    public GameObject DrillCharge;
        
    private RocketLauncher _rocket;

    private void Start()
    {
        _rocket = GetComponent<RocketLauncher>();
    }

    private void Update()
    {
        if (!GunControl.Instance.enabled)
        {
            return;
        }
            
        if (Inputs.AltFirePressed)
        {
            FireDrillCharge();
        }
    }

    private void FireDrillCharge()
    {
        CameraController cc = CameraController.Instance;
        GameObject drillCharge = Instantiate(DrillCharge, cc.transform.position + cc.transform.forward, cc.transform.rotation);
        drillCharge.GetComponent<Rigidbody>().AddForce(CameraController.Instance.transform.forward * 12f + 
                                                       (NewMovement.Instance.ridingRocket ? NewMovement.Instance.ridingRocket.rb.velocity : NewMovement.Instance.rb.velocity)
                                                       + (Vector3.up * 10), ForceMode.VelocityChange);
    }
}