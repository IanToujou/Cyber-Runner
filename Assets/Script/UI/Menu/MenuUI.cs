using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuUI : MonoBehaviour {
    
    public const int SPLASH = 0;
    public const int MAIN = 1;
    public const int SETTINGS = 2;
    public const int PROFILE = 3;

    [SerializeField] private GameObject splashUI;
    [SerializeField] private GameObject mainUI;
    [SerializeField] private GameObject settingsUI;
    [SerializeField] private GameObject profileUI;
    
    private static List<GameObject> uiList;
    private static int activeCanvas;

    void OnEnable() {
        uiList = new List<GameObject>();
        uiList.Add(splashUI);
        uiList.Add(mainUI);
        uiList.Add(settingsUI);
        uiList.Add(profileUI);
        SetActiveCanvas(SPLASH);
    }

    void Update() {
        if(activeCanvas == SETTINGS) {
            if(Input.GetKeyDown(KeyCode.Escape)) {
                SetActiveCanvas(MAIN);
            }
        } else if(activeCanvas == PROFILE) {
            if(Input.GetKeyDown(KeyCode.Escape)) {
                SetActiveCanvas(MAIN);
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
