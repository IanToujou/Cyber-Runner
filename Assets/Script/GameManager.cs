using UnityEngine;

public class GameManager : MonoBehaviour {
    
    [SerializeField] private GameObject player;

    private static GameObject staticPlayer;

    void Awake() {
        staticPlayer = player;
    }

    public static GameObject GetPlayer() {
        return staticPlayer;
    }

}
