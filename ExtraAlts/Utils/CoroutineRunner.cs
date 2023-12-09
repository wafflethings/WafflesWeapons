using UnityEngine;

namespace WafflesWeapons.Utils
{
    //Empty monobehaviour whos only purpose is to run coroutines lol
    public class CoroutineRunner : MonoBehaviour
    {
        private static CoroutineRunner _instance;
        public static CoroutineRunner Instance
        {
            get
            {
                if(_instance == null)
                {
                    _instance = new GameObject("WW Coroutines").AddComponent<CoroutineRunner>();
                    DontDestroyOnLoad(_instance.gameObject);
                }
                return _instance;
            }
        }
    }
}
