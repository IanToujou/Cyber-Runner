using UnityEngine;

public class LaneTrigger : MonoBehaviour {

    [SerializeField] private int maxLane;
    [SerializeField] private int minLane;

    private PlayerControls playerControls;

    void Start() {
        playerControls = GameManager.GetPlayer().GetComponent<PlayerControls>();
    }

    void OnTriggerEnter2D(Collider2D collider) {
        if(collider.CompareTag("Player")) {
            playerControls.SetMaxLane(maxLane);
            playerControls.SetMinLane(minLane);
        }
    }

}
