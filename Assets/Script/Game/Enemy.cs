using UnityEngine;

public class Enemy : MonoBehaviour {
    
    [SerializeField] private float health;
    
    private Animator animator;
    private GameObject player;

    void Start() {
        animator = GetComponentInChildren<Animator>();
        player = GameManager.GetPlayer();
    }

    void OnTriggerEnter2D(Collider2D collider) {
        if(collider.CompareTag("PlayerBullet")) {
            Hurt();
        }
    }

    public void Hurt() {
        health--;
        animator.SetTrigger("ReceiveDamage");
    }

}
