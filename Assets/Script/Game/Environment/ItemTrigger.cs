using UnityEngine;

public class ItemTrigger : MonoBehaviour
{

    [SerializeField] private GameObject weapon;
    private PlayerControls playerControls;
    private SpriteRenderer spriteHolder;

    void Start() {
        playerControls = GameManager.GetPlayer().GetComponent<PlayerControls>();
        spriteHolder = gameObject.GetComponentInChildren<SpriteRenderer>();
    }
    
    void OnTriggerEnter2D(Collider2D collider) {
        if(collider.CompareTag("Player")) {
            playerControls.SetWeapon(weapon);
            Destroy(this);
        }
    }

}
