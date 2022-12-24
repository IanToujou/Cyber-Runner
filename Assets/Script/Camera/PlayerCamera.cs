using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    
    [SerializeField] private GameObject player;

    public void Start() {
        gameObject.transform.position = new Vector3(0, -0.7f, -10);
    }

    public void Update() {
        gameObject.transform.position = new Vector3(player.transform.position.x + 5, -0.7f, -10);
    }

}
