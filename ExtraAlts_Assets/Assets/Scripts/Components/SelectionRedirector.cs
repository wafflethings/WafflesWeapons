using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

sealed class SelectionRedirector : Selectable
{
    public Selectable[] Selectables;

    public override void OnSelect(BaseEventData eventData) { }}
