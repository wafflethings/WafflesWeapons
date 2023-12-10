using System.Collections;
using UnityEngine;

namespace WafflesWeapons.Weapons.FerryOar
{
    public class ExposeTag : MonoBehaviour
    {
        public const float ExposeLength = 2.5f;
        public bool Done = false;
        public float TimeLeft = 0;
        private float _growTime;
        private Vector3 _targetScale;
        private GameObject _lightning;

        public void Start()
        {
            TimeLeft += ExposeLength;
            _lightning = Instantiate(FerryOar.LightningIndicator, transform.position, Quaternion.identity);
            _lightning.GetComponent<Follow>().target = transform;
            StartCoroutine(DestroyOverTime());
        }

        public void Update()
        {
            float rate = _targetScale.x == 0 ? Time.deltaTime * 5 : Time.deltaTime * (_targetScale.x / _growTime);
            _lightning.transform.localScale = Vector3.MoveTowards(_lightning.transform.localScale, _targetScale, rate);
        }

        public IEnumerator DestroyOverTime()
        {
            _growTime = 1f;
            _targetScale = new Vector3(0.5f, 1, 0.5f);
            while (TimeLeft > 0)
            {
                yield return null;
                TimeLeft -= Time.deltaTime;
            }
            _targetScale = new Vector3(0, 1, 0);
            _growTime = 0.1f;
            yield return new WaitForSeconds(0.1f);
            Destroy(this);
        }

        public void OnDestroy()
        {
            Destroy(_lightning);
        }
    }
}
