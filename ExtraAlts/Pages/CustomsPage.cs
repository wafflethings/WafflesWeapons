using Atlas.Modules.Terminal;
using ExtraAlts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace ExtraAlts.Pages
{
    public class CustomsPage : Page
    {
        public CustomsPage(GameObject go) : base(go)
        {
            GameObject page = GameObject.Instantiate(Core.Assets.LoadAsset<GameObject>("ExtraAlts Page.prefab"));
            page.transform.SetParent(go.transform, false);
            page.SetActive(false);
            Objects.Add(page);
        }
    }
}
