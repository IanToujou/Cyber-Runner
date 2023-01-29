using UnityEngine;

public class JumpTrigger : MonoBehaviour {
    
    [SerializeField] private int rampLane;

    private PlayerControls playerControls;

    void Start() {
        playerControls = GameManager.GetPlayer().GetComponent<PlayerControls>();
    }

    void OnTriggerEnter2D(Collider2D collider) {
        if(collider.CompareTag("Player")) {
            if(playerControls.GetCurrentLane() == rampLane) {
                playerControls.Jump();
            }
        }
    }

}
