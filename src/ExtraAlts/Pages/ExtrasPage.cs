using UnityEngine;
using AtlasLib.Pages;
using WafflesWeapons.Assets;

namespace WafflesWeapons.Pages
{
    public class ExtrasPage : Page
    {
        public override void CreatePage(Transform parent)
        {
            base.CreatePage(parent);
            Objects.Add(Object.Instantiate(AddressableManager.Load<GameObject>("Assets/ExtraAlts/ExtraAlts Alternate.prefab")));
        }
    }
}
