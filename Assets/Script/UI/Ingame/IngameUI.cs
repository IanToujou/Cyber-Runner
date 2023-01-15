using System.Collections.Generic;
using UnityEngine;

public class IngameUI : MonoBehaviour {

    public const int ENTRY = 0;
    public const int MAIN = 1;
    public const int DEATH = 2;

    [SerializeField] private GameObject entryUI;
    [SerializeField] private GameObject mainUI;
    [SerializeField] private GameObject deathUI;
    
    private static List<GameObject> uiList;
    private static int activeCanvas;
    
    void OnEnable() {
        uiList = new List<GameObject>();
        uiList.Add(entryUI);
        uiList.Add(mainUI);
        uiList.Add(deathUI);
        SetActiveCanvas(ENTRY);
    }

    void Update() {
        if(activeCanvas == DEATH) {
            if(Input.GetKeyDown(KeyCode.F)) {
                GameManager.SetLevel(1);
            }
        }
    }

    public static void SetActiveCanvas(int layout) {
        DeactivateAllCanvas();
        uiList[layout].SetActive(true);
        activeCanvas = layout;
    }

    public static void DeactivateAllCanvas() {
        foreach(GameObject all in uiList) {
            all.SetActive(false);
        }
    }
    
}
