using UnityEngine;
using AtlasLib.Pages;

namespace WafflesWeapons.Pages
{
    public class ExtrasPage : Page
    {
        public override void CreatePage(Transform parent)
        {
            base.CreatePage(parent);
            Objects.Add(Object.Instantiate(Plugin.Assets.LoadAsset<GameObject>("ExtraAlts Alternate.prefab")));
        }
    }
}
