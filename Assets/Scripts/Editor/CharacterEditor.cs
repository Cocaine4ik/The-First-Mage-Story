using UnityEditor;
using UnityEngine;
using UnityEditor.AnimatedValues;

[CustomEditor(typeof(MonoBehaviour))]
public class CharacterEditor : Editor {

    AnimBool jumpSettings;
    Character character;

    private void OnEnable() {

        character = (Character)target;
        jumpSettings = new AnimBool(false);
    }

}
