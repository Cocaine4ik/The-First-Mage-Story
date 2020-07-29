using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActionPanelCell<T> : MonoBehaviour
{
    [SerializeField] protected int id;
    [SerializeField] protected Image image;
    protected T invoker;

    public int Id => id;
    public Image Image => image;
    public T Invoker => invoker;

    protected virtual void Start() {
        invoker = GetComponent<T>();
    }

}
