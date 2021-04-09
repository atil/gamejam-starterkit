using UnityEngine;
using UnityEditor;
using UnityEditorInternal;

namespace JamKit
{
    public static class EditorUtils
    {
        [MenuItem("GameJam/Top View #&q", false, 10)]
        private static void TopView()
        {
            SceneView s = SceneView.sceneViews[0] as SceneView;
            s.LookAt(s.pivot, Quaternion.LookRotation(new Vector3(0, -1, 0)), s.size, true);
            s.orthographic = true;
        }

        [MenuItem("GameJam/Compile and Play #&p", false, 10)]
        private static void CompileAndPlay()
        {
            AssetDatabase.Refresh();
            EditorApplication.isPlaying = true;
        }

        [MenuItem("GameJam/Toggle profiler &k", false, 10)]
        private static void ToggleProfiler()
        {
            ProfilerDriver.enabled = !ProfilerDriver.enabled;
        }

        // Called from the build script
        private static void BuildWebGL()
        {
            string[] scenes =
            {
                "Assets/Scenes/Splash.unity",
                "Assets/Scenes/Game.unity",
                "Assets/Scenes/End.unity",
            };

            const string buildPath = "Build/WebGL";

            BuildPipeline.BuildPlayer(scenes, buildPath, BuildTarget.WebGL, BuildOptions.None);
        }
    }
}