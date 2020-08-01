using System;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

namespace Utilities
{
    public static class SceneUtilities
    {
        public static List<string> AvailableScenes()
        {
            var sceneNameList = new List<string>();

            for (var i = 0; i < SceneManager.sceneCountInBuildSettings; i++)
            {
                var scenePath = SceneUtility.GetScenePathByBuildIndex(i);
                var lastSlash = scenePath.LastIndexOf("/", StringComparison.Ordinal);
                var sceneName = scenePath.Substring(lastSlash + 1, scenePath.LastIndexOf(".", StringComparison.Ordinal) - lastSlash - 1);

                sceneNameList.Add(sceneName);
            }

            return sceneNameList;
        }

        /// <summary>
        /// <param name="name">The potential scene name to check.</param>
        /// <returns>True if the scene 'name' exists and is in your Build settings, false otherwise</returns>
        /// </summary>
        public static bool IsValidSceneName(string name)
        {
            if (string.IsNullOrEmpty(name))
                return false;

            for (var i = 0; i < SceneManager.sceneCountInBuildSettings; i++)
            {
                var scenePath = SceneUtility.GetScenePathByBuildIndex(i);
                var lastSlash = scenePath.LastIndexOf("/", StringComparison.Ordinal);
                var sceneName = scenePath.Substring(lastSlash + 1, scenePath.LastIndexOf(".", StringComparison.Ordinal) - lastSlash - 1);

                if (string.Compare(name, sceneName, StringComparison.Ordinal) == 0)
                    return true;
            }

            return false;
        }
    }
}
