using System.Collections.Generic;
using UnityEditor;

namespace _Main.Scripts.SceneSystem.Abstract
{
    public static class SceneUtility
    {
#if UNITY_EDITOR
        public static List<string> GetSceneNames()
        {
            List<string> sceneNames = new List<string>();
            foreach (EditorBuildSettingsScene scene in EditorBuildSettings.scenes)
            {
                if (scene.enabled)
                {
                    string scenePath = scene.path;
                    string sceneName = System.IO.Path.GetFileNameWithoutExtension(scenePath);
                    sceneNames.Add(sceneName);
                }
            }

            return sceneNames;
        }
#endif
    }
}