using UnityEngine;
using UnityEditor;
using System;

[CustomPropertyDrawer(typeof(SliderAttribute))]
public class SliderDrawer : PropertyDrawer {

    // Draw the property inside the given rect
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label) {
        // First get the attribute since it contains the range for the slider
        SliderAttribute slider = attribute as SliderAttribute;

        // Now draw the property as a Slider or an IntSlider based on whether it's a float or integer.
        if (property.propertyType == SerializedPropertyType.Float)
            EditorGUI.Slider(position, property, slider.min, slider.max, label);
        else if (property.propertyType == SerializedPropertyType.Integer)
            EditorGUI.IntSlider(position, property, Convert.ToInt32(slider.min), Convert.ToInt32(slider.max), label);
        else
            EditorGUI.LabelField(position, label.text, "Use Range with float or int.");
    }
}