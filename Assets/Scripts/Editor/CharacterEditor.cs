using UnityEditor;

[CustomEditor(typeof(Character))]
 public class CharacterEditor : Editor {

    protected static bool showJumpSetting = false; //declare outside of function
    private Character character;

    private void OnEnable() {

        character = target as Character;
    }

    public override void OnInspectorGUI() {

        base.OnInspectorGUI();
        showJumpSetting = EditorGUILayout.Foldout(showJumpSetting, "Jump Setting");
        
        if (showJumpSetting) {

            character.CheckRadious = EditorGUILayout.FloatField("Jump Checking Radius", character.CheckRadious);
            character.JumpForce = EditorGUILayout.FloatField("Jump Force", character.JumpForce);
            character.JumpControlTime = EditorGUILayout.FloatField("Jump Control Time", character.JumpControlTime);

        }
    }
}
