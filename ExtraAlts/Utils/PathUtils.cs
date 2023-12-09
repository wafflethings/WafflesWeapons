using System.IO;
using System.Reflection;
using BepInEx;
using UnityEngine;

namespace WafflesWeapons.Utils
{
    public static class PathUtils
    {
        public static string GameDirectory()
        {
            string path = Application.dataPath;
            if (Application.platform == RuntimePlatform.OSXPlayer)
            {
                path = Utility.ParentDirectory(path, 2);
            }
            else if (Application.platform == RuntimePlatform.WindowsPlayer)
            {
                path = Utility.ParentDirectory(path, 1);
            }

            return path;
        }

        public static string ModDirectory()
        {
            return Path.Combine(GameDirectory(), "BepInEx", "plugins");
        }

        public static string ModPath()
        {
            return Assembly.GetCallingAssembly().Location.Substring(0, Assembly.GetCallingAssembly().Location.LastIndexOf(Path.DirectorySeparatorChar));
        }
    }
}