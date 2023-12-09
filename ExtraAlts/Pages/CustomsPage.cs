using WafflesWeapons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Atlas.Modules.Terminal;
using WafflesWeapons.Components;
using WafflesWeapons.Utils;

namespace WafflesWeapons.Pages
{
    public class CustomsPage : Page
    {
        public CustomsPage(GameObject go) : base(go)
        {
            GameObject page = GameObject.Instantiate(Core.Assets.LoadAsset<GameObject>("ExtraAlts Page.prefab"), go.transform);
            Objects.Add(page);
        }
    }
}
