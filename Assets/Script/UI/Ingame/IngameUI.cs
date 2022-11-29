using System.Collections.Generic;
using UnityEngine;

public class IngameUI : MonoBehaviour {

    public const int MAIN = 0;
    public const int DEATH = 1;

    [SerializeField] private GameObject mainUI;
    [SerializeField] private GameObject deathUI;
    
    private static List<GameObject> uiList;
    
    void OnEnable() {
        uiList = new List<GameObject>();
        uiList.Add(mainUI);
        uiList.Add(deathUI);
        SetActiveCanvas(MAIN);
    }

    public static void SetActiveCanvas(int layout) {
        DeactivateAllCanvas();
        uiList[layout].SetActive(true);
    }

    public static void DeactivateAllCanvas() {
        foreach(GameObject all in uiList) {
            all.SetActive(false);
        }
    }
    
}
