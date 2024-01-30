using System;
using System.Collections;
using AtlasLib.Utils;
using UnityEngine;

namespace WafflesWeapons.Components
{
    public class CopyActiveState : MonoBehaviour
    {
        public GameObject Target;
        private Coroutine _currentCoroutine;

        public void Start()
        {
            _currentCoroutine = CoroutineRunner.Instance.StartCoroutine(SetEnabled());
        }

        public void OnDestroy()
        {
            CoroutineRunner.Instance.StopCoroutine(_currentCoroutine);
        }

        public IEnumerator SetEnabled()
        {
            while (true)
            {
                if (Target != null)
                {
                    gameObject.SetActive(Target.activeInHierarchy);
                }

                yield return null;
            }
        }
    }
}
