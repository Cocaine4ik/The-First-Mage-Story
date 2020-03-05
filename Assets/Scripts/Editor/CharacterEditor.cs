using UnityEditor;
/// <summary>
/// Player script custom inspector
/// </summary>
[CustomEditor(typeof(Player))]
public class PlayerEditor : CharacterEditor { }

/// <summary>
/// RangeCharacter script custom  inspector
/// </summary>
[CustomEditor(typeof(RangeCharacter))]
public class RangeCharacterEditor : CharacterEditor {}

/// <summary>
/// MagicCharacter script custom  inspector
/// </summary>
[CustomEditor(typeof(MagicCharacter))]
public class MagicCharacterEditor : CharacterEditor { }

/// <summary>
/// Character script custom  inspector
/// </summary>
[CustomEditor(typeof(Character))]
 public class CharacterEditor : Editor {

    protected static bool showJumpSetting = false; //declare outside of function
    protected Character character;

    private void OnEnable() {

        character = target as Character;
        
    }
    /// <summary>
    /// Add Jump Setting foldout
    /// </summary>
    public override void OnInspectorGUI() {

        base.OnInspectorGUI();
        showJumpSetting = EditorGUILayout.Foldout(showJumpSetting, "Jump Setting");
        
        if (showJumpSetting) {
            serializedObject.FindProperty("checkRadius").floatValue = EditorGUILayout.FloatField("Jump Checking Radius", character.CheckRadius);
            serializedObject.FindProperty("jumpForce").floatValue = EditorGUILayout.FloatField("Jump Force", character.JumpForce);
            serializedObject.FindProperty("jumpControlTime").floatValue = EditorGUILayout.FloatField("Jump Control Time", character.JumpControlTime);

        }
        serializedObject.ApplyModifiedProperties();
    }


}
