using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {
    
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject cameraHolder;
    [SerializeField] private MusicManager musicManager;

    private static GameObject staticPlayer;
    private static GameObject staticCameraHolder;
    private static MusicManager staticMusicManager;

    void Awake() {
        staticPlayer = player;
        staticCameraHolder = cameraHolder;
        staticMusicManager = musicManager;
    }

    public static GameObject GetPlayer() {
        return staticPlayer;
    }

    public static GameObject GetCameraHolder() {
        return staticCameraHolder;
    }

    public static MusicManager GetMusicManager() {
        return staticMusicManager;
    }

    public static void SetLevel(int level) {
        SceneManager.LoadScene(level);
    }

}
