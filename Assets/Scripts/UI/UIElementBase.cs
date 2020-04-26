using UnityEngine;
using UnityEngine.UI; //Required when using UI Elements.
using UnityEngine.EventSystems; // Required when using event data.

// base UI element class
public class UIElementBase: MonoBehaviour, IPointerDownHandler {

    protected RectTransform panelRectTransform;
    public RectTransform PanelRectTransform => panelRectTransform;

    protected virtual void Start() {
        panelRectTransform = GetComponent<RectTransform>();
    }
    public void OnPointerDown(PointerEventData eventData) {
        panelRectTransform.SetAsLastSibling();
    }
}
