using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuUI : MonoBehaviour {
    
    public const int SPLASH = 0;
    public const int MAIN = 1;
    public const int PLAY = 2;
    public const int HARDCORE = 3;
    public const int PROGRESS = 4;
    public const int SETTINGS = 5;
    public const int EXIT = 6;

    [SerializeField] private GameObject splashUI;
    [SerializeField] private GameObject mainUI;
    
    private static List<GameObject> uiList;

    void Update() {
        if(Input.GetKeyDown(KeyCode.H)) {
            SceneManager.LoadScene(1);
        }
    }
    
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
