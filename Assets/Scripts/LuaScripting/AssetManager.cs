using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace LuaScripting
{
    /// <summary>
    /// A class to use for loading/unloading assets.
    /// </summary>
    public class AssetManager : MonoBehaviour
    {
        public static readonly string AssetBundlesPath = Path.Combine(Application.streamingAssetsPath, "AssetBundles");

        /// <summary>
        /// A dictionary holding all the loaded asset bundles.
        /// </summary>
        public static Dictionary<string, AssetBundle> LoadedAssetBundles = new Dictionary<string, AssetBundle>();

        /// <summary>
        /// Loads an asset from a specified asset bundle.
        /// </summary>
        /// <typeparam name="T">The type of the asset. (eg. GameObject)</typeparam>
        /// <param name="assetName">The name of the asset inside the asset bundle.</param>
        /// <param name="assetBundle">The name of the asset bundle inside the AssetBundlePath.</param>
        /// <returns></returns>
        public T LoadAsset<T>(string assetName, string assetBundle) where T : Object
        {
            if (!LoadedAssetBundles.ContainsKey(assetBundle))
            {
                LoadAssetBundle(assetBundle);
            }

            return LoadedAssetBundles.ContainsKey(assetBundle) ? LoadedAssetBundles[assetBundle].LoadAsset<T>(assetName) : default;
        }

        /// <summary>
        /// Loads an asset bundle.
        /// </summary>
        /// <param name="assetBundleName">The name of the asset bundle inside the AssetBundlePath.</param>
        public void LoadAssetBundle(string assetBundleName)
        {
            var myLoadedAssetBundle = AssetBundle.LoadFromFile(Path.Combine(AssetBundlesPath, assetBundleName));

            if (myLoadedAssetBundle == null)
            {
                Debug.LogError($"Failed to load AssetBundle: {assetBundleName}");
                return;
            }

            LoadedAssetBundles.Add(assetBundleName, myLoadedAssetBundle);
        }

        /// <summary>
        /// Unloads an asset bundle.
        /// </summary>
        /// <param name="assetBundleName">The name of the asset bundle inside the AssetBundlePath.</param>
        /// <param name="unloadAllLoadedObjects"></param>
        public void UnloadAssetBundle(string assetBundleName, bool unloadAllLoadedObjects = true)
        {
            if (LoadedAssetBundles.TryGetValue(assetBundleName, out var assetBundle))
            {
                assetBundle.Unload(unloadAllLoadedObjects);
                LoadedAssetBundles.Remove(assetBundleName);
            }
            else
            {
                Debug.LogWarning($"{assetBundleName} was not loaded.");
            }
        }

        /// <summary>
        /// Unloads all loaded asset bundles.
        /// </summary>
        /// <param name="unloadAllLoadedObjects"></param>
        public void UnloadAllAssetBundles(bool unloadAllLoadedObjects = true)
        {
            foreach (var keyValuePair in LoadedAssetBundles)
            {
                keyValuePair.Value.Unload(unloadAllLoadedObjects);
            }

            LoadedAssetBundles.Clear();
        }

        /// <summary>
        /// NOT TESTED YET.
        /// </summary>
        /// <typeparam name="T">The type of the asset to instantiate.</typeparam>
        /// <param name="assetName">The name of the asset inside the asset bundle.</param>
        /// <param name="assetBundle">The name of the asset bundle inside the AssetBundlePath.</param>
        /// <returns></returns>
        public IEnumerator InstantiateObjectAsync<T>(string assetName, string assetBundle) where T : Object
        {
            if (!LoadedAssetBundles.ContainsKey(assetBundle))
            {
                yield return LoadAssetBundleAsync(assetBundle);
            }

            var assetLoadRequest = LoadedAssetBundles[assetBundle].LoadAssetAsync<T>(assetName);

            yield return assetLoadRequest;

            var prefab = assetLoadRequest.asset as T;

            Instantiate(prefab);
        }

        /// <summary>
        /// NOT TESTED YET.
        /// </summary>
        /// <param name="assetBundleName">The name of the asset bundle inside the AssetBundlePath.</param>
        /// <returns></returns>
        private static IEnumerator LoadAssetBundleAsync(string assetBundleName)
        {
            var bundleLoadRequest = AssetBundle.LoadFromFileAsync(Path.Combine(AssetBundlesPath, assetBundleName));
            yield return bundleLoadRequest;

            var myLoadedAssetBundle = bundleLoadRequest.assetBundle;
            if (myLoadedAssetBundle == null)
            {
                Debug.LogError($"Failed to load AssetBundle: {assetBundleName}");
                yield break;
            }
            
            LoadedAssetBundles.Add(assetBundleName, myLoadedAssetBundle);
        }
    }
}
