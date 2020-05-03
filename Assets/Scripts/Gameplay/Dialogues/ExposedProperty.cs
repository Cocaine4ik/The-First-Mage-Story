using UnityEngine;

[System.Serializable]
public class ExposedProperty {

    public string PropertyName = "New String";
    public string PropertyValue = "New Value";

    public ExposedProperty() {}

    public ExposedProperty(string name, string value) {
        PropertyName = name;
        PropertyValue = value;
    }

    public void Localize() {
        var localizationKey = "Properties." + PropertyName;
        PropertyValue = LocalizationManager.Localize(localizationKey, GetType().ToString());
    }

}
