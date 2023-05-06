using WafflesWeapons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Atlas.Modules.Terminal;

namespace WafflesWeapons.Pages
{
    public class ExtrasPage : Page
    {
        public ExtrasPage(GameObject go) : base(go)
        {
            GameObject page = GameObject.Instantiate(Core.Assets.LoadAsset<GameObject>("ExtraAlts Alternate.prefab"));
            page.transform.SetParent(go.transform, false);
            page.SetActive(false);
            Objects.Add(page);
        }
    }
}
