using System.Collections;
using UnityEngine;

public class Enemy : MonoBehaviour {
    
    [SerializeField] private float health;
    
    private Animator animator;
    private GameObject player;
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
        Debug.Log("Hit");
        health--;
        animator.SetTrigger("ReceiveDamage");
        Destroy(bullet);
    }

    public IEnumerator StartHitCooldown() {
        yield return new WaitForSeconds(0.1f);
        coolingDownHit = false;
    }

}
