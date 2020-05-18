using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Networking;

/// <summary>
/// Downloads spritesheets from Google Spreadsheet and saves them to Resources. My laziness made me to create it.
/// </summary>
[ExecuteInEditMode]
	public class DataSync : MonoBehaviour
	{

    /// <summary>
    /// Table id on Google Spreadsheet.
    /// Let's say your table has the following url https://docs.google.com/spreadsheets/d/1RvKY3VE_y5FPhEECCa5dv4F7REJ7rBtGzQg9Z_B_DE4/edit#gid=331980525
    /// So your table id will be "1RvKY3VE_y5FPhEECCa5dv4F7REJ7rBtGzQg9Z_B_DE4" and sheet id will be "331980525" (gid parameter)
    /// </summary>
    /// 
    [Header("Localization Data:")]
		public string LocalizationTableId;

		/// <summary>
		/// Table sheet contains sheet name and id. First sheet has always zero id. Sheet name is used when saving.
		/// </summary>
		public Sheet[] LocalizationSheets;

		/// <summary>
		/// Folder to save spreadsheets. Must be inside Resources folder.
		/// </summary>
		public UnityEngine.Object LocalizationSaveFolder;

        [Header("Configuration Data:")]
        public string ConfigurationTableId;
        public Sheet[] ConfigurationSheets;
        public UnityEngine.Object ConfigurationSaveFolder;

        private const string UrlPattern = "https://docs.google.com/spreadsheets/d/{0}/export?format=csv&gid={1}";
        private bool dataSynced = false;
		#if UNITY_EDITOR

		/// <summary>
		/// Sync spreadsheets.
		/// </summary>
		public void Sync()
		{

			StopAllCoroutines();
			StartCoroutine(SyncCoroutine(LocalizationSaveFolder, LocalizationSheets, LocalizationTableId));
            StartCoroutine(SyncCoroutine(ConfigurationSaveFolder, ConfigurationSheets, ConfigurationTableId));
        }

        private IEnumerator SyncCoroutine(UnityEngine.Object saveFolder, Sheet[] sheets, string tableId)
		{
            var folder = UnityEditor.AssetDatabase.GetAssetPath(saveFolder);

			Debug.Log("<color=yellow>Sync started, please wait for confirmation message...</color>");


			var downloaders = new List<UnityWebRequest>();

            foreach (var sheet in sheets)
			{
				var url = string.Format(UrlPattern, tableId, sheet.Id);

				Debug.LogFormat("Downloading: {0}...", url);
                downloaders.Add(UnityWebRequest.Get(url));

			}

			foreach (var downloader in downloaders)
			{
            downloader.SendWebRequest();
				if (!downloader.isDone)
				{
					yield return downloader;
				}

				if (downloader.error == null)
				{
                    var sheet = sheets.Single(i => downloader.url == string.Format(UrlPattern, tableId, i.Id));
                    var path = System.IO.Path.Combine(folder, sheet.Name + ".csv");

					System.IO.File.WriteAllBytes(path, downloader.downloadHandler.data);
					UnityEditor.AssetDatabase.Refresh();

                    Debug.LogFormat("Sheet {0} downloaded to {1}", sheet.Id, path);
            }
				else
				{
					throw new Exception(downloader.error);
				}
			}

			Debug.Log("<color=green>Data successfully synced!</color>");
		}

		#endif
	}