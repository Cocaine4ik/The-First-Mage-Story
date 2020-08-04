using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public abstract class Cell<T> : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    protected bool onPanel;
    protected bool canDrag = false;
    [SerializeField] protected Image icon;
    protected GameObject draggingCell;
    protected GameObject panelCell;
    protected Cell<T> draggingCellData;

    public Image Icon => icon;
    public bool OnPanel => onPanel;
    public GameObject PanelCell { get => panelCell; set => panelCell = value; }

    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<SpellPanelCell>() != null)
        {
            onPanel = true;
            panelCell = collision.gameObject;
            Debug.Log("onPanel: " + onPanel);
        }
    }

    public virtual void OnBeginDrag(PointerEventData eventData)
    {
        if (canDrag)
        {
            draggingCell = Instantiate(gameObject, gameObject.transform.parent.transform.parent);
            draggingCell.transform.position = Input.mousePosition;
            SetDragginCellData();
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (canDrag)
        {
            draggingCell.transform.position = Input.mousePosition;
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (canDrag)
        {
            draggingCellData.SetPanelCell();
            Destroy(draggingCell);
        }
    }

    public abstract void SetPanelCell();
    protected virtual void SetDragginCellData()
    {
        draggingCellData = draggingCell.GetComponent<Cell<T>>();
    }
}

