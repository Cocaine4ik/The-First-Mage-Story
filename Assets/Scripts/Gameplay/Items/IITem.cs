﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IITem {

    Sprite ItemIcon { get; }
    Color32 ItemColor { get; }

    /// <summary>
    /// keys for localiztion
    /// </summary>
    string ItemNameKey { get;  }
    string ItemTypeKey { get; }
    string ItemDescriptionKey { get; }


}