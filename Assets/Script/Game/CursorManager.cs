using UnityEngine;

public class CursorManager : MonoBehaviour {
    
    [SerializeField] private Texture2D defaultCursor;
    [SerializeField] private Texture2D reloadCursor;
    [SerializeField] private Texture2D shootCursor;


    void Start() {
        SetCursor("DEFAULT");
    }

    public void SetCursor(string type) {
        if(type.Equals("DEFAULT")) Cursor.SetCursor(defaultCursor, new Vector2(8f, 8f), CursorMode.Auto);
        if(type.Equals("RELOAD")) Cursor.SetCursor(defaultCursor, new Vector2(8f, 8f), CursorMode.Auto);
        if(type.Equals("SHOOT")) Cursor.SetCursor(defaultCursor, new Vector2(8f, 8f), CursorMode.Auto);
    }

}
