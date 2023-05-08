using System.Collections.Generic;

namespace Logic
{
    public class VarStore
    {
        public Dictionary<string, int> intStore = new Dictionary<string, int>();
        public Dictionary<string, bool> boolStore = new Dictionary<string, bool>();
        public Dictionary<string, float> floatStore = new Dictionary<string, float>();
        public Dictionary<string, string> stringStore = new Dictionary<string, string>();
        
        public void Clear() { }    }
}