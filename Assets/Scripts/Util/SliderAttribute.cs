using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SliderAttribute : PropertyAttribute {

    public float min;
    public float max;

    public SliderAttribute(float min, float max) {
        this.min = min;
        this.max = max;
    }
}
