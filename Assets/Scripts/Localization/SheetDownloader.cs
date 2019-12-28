using System;
using System.Collections;
using UnityEngine;

    /// <summary>
    /// HTTP downloader with WWW utility (creates instance automatically)
    /// </summary>
    [ExecuteInEditMode]
    public class SheetDownloader : MonoBehaviour
    {
        public static event Action OnNetworkReady = () => { }; 

        private static SheetDownloader instance;

	    public static SheetDownloader Instance
        {
            get { return instance ?? (instance = new GameObject("SheetDownloader").AddComponent<SheetDownloader>()); }
        }

        public void OnDestroy()
        {
            instance = null;
        }
       
        public static void Download(string url, Action<WWW> callback)
        {
            Debug.LogFormat("downloading {0}", url);
            Instance.StartCoroutine(Coroutine(url, callback));
        }

        private static IEnumerator Coroutine(string url, Action<WWW> callback)
        {
            var www = new WWW(url);

            yield return www;

            Debug.LogFormat("downloaded {0}, www.text = {1}, www.error = {2}", url, CleaunupText(www.text), www.error);

            if (www.error == null)
            {
                OnNetworkReady();
            }

            callback(www);
        }

        private static string CleaunupText(string text)
        {
            return text.Replace("\n", " ").Replace("\t", null);
        }
    }