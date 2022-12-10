using UnityEngine;

public class FightTriggerEnd : MonoBehaviour {
    
    [SerializeField] private Transform firstTrigger;
    
    private bool canLeave;

    void Start() {
        canLeave = false;
    }

    void OnTriggerEnter2D(Collider2D collider) {

        if(canLeave) return;
        if(collider.CompareTag("Player")) {
            GameObject player = collider.gameObject;
            player.transform.position = new Vector3(firstTrigger.position.x, player.transform.position.y, player.transform.position.z);
        }
        
    }

    public void SetCanLeave(bool canLeave) {
        this.canLeave = canLeave;
    }

    public bool CanLeave() {
        return canLeave;
    }

}
