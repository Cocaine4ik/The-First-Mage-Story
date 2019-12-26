using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class LocalizationData {

    private LocalizationItem[] items;

}

[System.Serializable]
public class LocalizationItem {

    private string key;
    private string value;
 }
