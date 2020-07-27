using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActionPanelCell<T> : MonoBehaviour
{
    [SerializeField] protected int id;
    protected Image image;
    protected T invoker;

    public int Id => id;
    public Image Image => image;
    public T Invoker => invoker;

    protected void Start() {
        image = GetComponent<Image>();
        invoker = GetComponent<T>();
    }

}
