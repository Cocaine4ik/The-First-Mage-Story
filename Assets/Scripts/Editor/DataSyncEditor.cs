using UnityEditor;
using UnityEngine;

	/// <summary>
	/// Adds "Sync" button to DataSync script.
	/// </summary>
	[CustomEditor(typeof(DataSync))]
    public class DataSyncEditor : UnityEditor.Editor
    {
        public override void OnInspectorGUI()
        {
            DrawDefaultInspector();

            var component = (DataSync) target;

            if (GUILayout.Button("SyncLocalization"))
            {
	            component.SyncLocalization();
            }
            if (GUILayout.Button("SyncConfigurationData")) {
            component.SyncConfigurationData();
            }
    }
    }