using System.Collections;
using UnityEngine;

public class Enemy : MonoBehaviour {
    
    [SerializeField] private bool obstacle;
    [SerializeField] private int maxHealth;
    [SerializeField] private int maxShield;
    
    private Animator animator;
    private GameObject player;
    private GameObject cameraHolder;
    private int health;
    private int shield;
    private bool coolingDownHit;
    private bool dead;

    void Start() {
        animator = GetComponentInChildren<Animator>();
        player = GameManager.GetPlayer();
        cameraHolder = GameManager.getCameraHolder();
        health = maxHealth;
        shield = maxShield;
        coolingDownHit = false;
        dead = false;
        if(!obstacle) transform.parent = cameraHolder.transform;
    }

    void Update() {
        if(health <= 0) {
            Death();
            return;
        }
    }

    void OnTriggerEnter2D(Collider2D collider) {
        if(dead) return;
        if(collider.CompareTag("PlayerBullet")) {
            if(coolingDownHit) return;
            coolingDownHit = true;
            StartCoroutine(StartHitCooldown());
            Hurt(collider.gameObject);
        }
    }

    public void Hurt(GameObject bullet) {
        if(dead) return;
        if(shield > 0) {
            shield -= bullet.GetComponent<Bullet>().GetDamage();
        } else {
            health -= bullet.GetComponent<Bullet>().GetDamage();
        }
        animator.SetTrigger("Hurt");
        Destroy(bullet);
    }

    public void Attack() {
        if(dead) return;
        animator.SetTrigger("Attack");
    }

    public void Death() {
        dead = true;
        animator.SetTrigger("Death");
        Destroy(gameObject);
    }

    public IEnumerator StartHitCooldown() {
        yield return new WaitForSeconds(0.1f);
        coolingDownHit = false;
    }

}
