using System;
using UnityEngine;
using UnityEngine.UI;

	/// <summary>
	/// Asset usage example.
	/// </summary>
	public class LocalizationTool : MonoBehaviour
	{

		/// <summary>
		/// Called on app start.
		/// </summary>
		public void Awake()
		{
			LocalizationManager.Read();

			switch (Application.systemLanguage)
			{

                case SystemLanguage.English:
                    LocalizationManager.Language = "English";
                    break;
				case SystemLanguage.German:
					LocalizationManager.Language = "German";
					break;
				case SystemLanguage.Spanish:
					LocalizationManager.Language = "Spanish";
					break;
                case SystemLanguage.Ukrainian:
                    LocalizationManager.Language = "Ukrainian";
                    break;
			}
		}

		/// <summary>
		/// Change localization at runtime
		/// </summary>
		public void SetLocalization(string localization)
		{
			LocalizationManager.Language = localization;
		}

	}