using System.Collections.Generic;
using _Main.Scripts.SceneSystem.Abstract;

namespace _Main.Scripts.SceneSystem.Editor
{
#if UNITY_EDITOR
    using UnityEditor;
    using System.IO;

    public class EnumGenerator : Editor
    {
        [MenuItem("Tools/Generate Scene Enum")]
        public static void GenerateSceneEnum()
        {
            List<string> sceneNames = SceneUtility.GetSceneNames();

            string enumName = "SceneNames";
            string filePathAndName = "Assets/_Main/Scripts/SceneSystem/Abstract" + enumName + ".cs";

            using (StreamWriter streamWriter = new StreamWriter(filePathAndName))
            {
                streamWriter.WriteLine("public enum " + enumName);
                streamWriter.WriteLine("{");

                for (int i = 0; i < sceneNames.Count; i++)
                {
                    streamWriter.WriteLine("    " + sceneNames[i] + (i < sceneNames.Count - 1 ? "," : ""));
                }

                streamWriter.WriteLine("}");
            }

            AssetDatabase.Refresh();
        }
    }
#endif
}