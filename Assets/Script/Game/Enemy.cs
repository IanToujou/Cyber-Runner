using System.Collections;
using UnityEngine;

public class Enemy : MonoBehaviour {
    
    [SerializeField] private int maxHealth;
    [SerializeField] private int maxShield;
    
    private Animator animator;
    private GameObject player;
    private int health;
    private int shield;
    private bool coolingDownHit;

    void Start() {
        animator = GetComponentInChildren<Animator>();
        player = GameManager.GetPlayer();
        coolingDownHit = false;
    }

    void OnTriggerEnter2D(Collider2D collider) {
        if(collider.CompareTag("PlayerBullet")) {
            if(coolingDownHit) return;
            coolingDownHit = true;
            StartCoroutine(StartHitCooldown());
            Hurt(collider.gameObject);
        }
    }

    public void Hurt(GameObject bullet) {
        if(shield > 0) {
            shield--;
        } else {
            health--;
        }
        animator.SetTrigger("ReceiveDamage");
        Destroy(bullet);
    }

    public IEnumerator StartHitCooldown() {
        yield return new WaitForSeconds(0.1f);
        coolingDownHit = false;
    }

}
