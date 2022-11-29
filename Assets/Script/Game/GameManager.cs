using UnityEngine;

public class GameManager : MonoBehaviour {
    
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject cameraHolder;

    private static GameObject staticPlayer;
    private static GameObject staticCameraHolder;

    void Awake() {
        staticPlayer = player;
        staticCameraHolder = cameraHolder;
    }

    public static GameObject GetPlayer() {
        return staticPlayer;
    }

    public static GameObject getCameraHolder() {
        return staticCameraHolder;
    }

}
