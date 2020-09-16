using UnityEngine;

[System.Serializable]
public class ExposedProperty {

    public string PropertyName = "New String";
    public string PropertyValue = "New Value";
    public Sprite Portrait;

    public ExposedProperty() {}

    public ExposedProperty(string name, string value)
    {

        PropertyName = name;
        PropertyValue = value;
    }

    public ExposedProperty(string name, string value, Sprite portrait) {

        PropertyName = name;
        PropertyValue = value;
        Portrait = portrait;
    }

    public void Localize() {
        var localizationKey = "Properties." + PropertyName;
        PropertyValue = LocalizationManager.Localize(localizationKey, GetType().ToString());
    }

}
