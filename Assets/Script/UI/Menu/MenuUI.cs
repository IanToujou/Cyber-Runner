using System.Collections.Generic;
using UnityEngine;

public class MenuUI : MonoBehaviour {
    
    public const int SPLASH = 0;
    public const int MAIN = 1;

    [SerializeField] private GameObject splashUI;
    [SerializeField] private GameObject mainUI;
    
    private static List<GameObject> uiList;
    
    void OnEnable() {
        uiList = new List<GameObject>();
        uiList.Add(splashUI);
        uiList.Add(mainUI);
        SetActiveCanvas(SPLASH);
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
