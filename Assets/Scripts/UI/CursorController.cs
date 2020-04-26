using UnityEngine;

/// <summary>
/// Cursor controller
/// </summary>
public class CursorController : MonoBehaviour
{
    [Header("Cursor textures: ")]
    [SerializeField] private Texture2D cursor;
    [SerializeField] private Texture2D cursorOnClick;

    private void Awake() {
        Cursor.SetCursor(cursor, Vector2.zero, CursorMode.Auto);
    }

    private void Update() {

        if(Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1)) {
            Cursor.SetCursor(cursorOnClick, Vector2.zero, CursorMode.Auto);
        }
        if(Input.GetMouseButtonUp(0) || Input.GetMouseButtonUp(1)) {
            Cursor.SetCursor(cursor, Vector2.zero, CursorMode.Auto);
        }
    }
}
