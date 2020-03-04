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
    private Character character;

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

            character.CheckRadious = EditorGUILayout.FloatField("Jump Checking Radius", character.CheckRadious);
            character.JumpForce = EditorGUILayout.FloatField("Jump Force", character.JumpForce);
            character.JumpControlTime = EditorGUILayout.FloatField("Jump Control Time", character.JumpControlTime);

        }
    }


}
