using System.Collections;
using UnityEngine;

public class Enemy : MonoBehaviour {
    
    [SerializeField] private bool obstacle;
    [SerializeField] private int maxHealth;
    [SerializeField] private int maxShield;
    [SerializeField] private AudioSource deathAudioSource;
    [SerializeField] private GameObject deathEffectPrefab;
    [SerializeField] private string attackScript;
    
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

        if(!obstacle) Attack();

    }

    void OnTriggerEnter2D(Collider2D collider) {
        if(dead) return;
        if(collider.CompareTag("PlayerBullet")) {
            if(coolingDownHit) return;
            coolingDownHit = true;
            StartCoroutine(StartHitCooldown());
            Hurt(collider.gameObject);
        } else if(collider.CompareTag("Player")) {
            Death();
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

        //Attack script
        if(attackScript.Equals("PoliceHelicopter")) {
            PoliceHelicopter script = GetComponent<PoliceHelicopter>();
            script.Attack();
        } else if(attackScript.Equals("PoliceTank")) {
            PoliceTank script = GetComponent<PoliceTank>();
            script.Attack();
        } else if(attackScript.Equals("PoliceJeep")) {
            PoliceJeep script = GetComponent<PoliceJeep>();
            script.Attack();
        } else if(attackScript.Equals("PoliceHover")) {
            PoliceHover script = GetComponent<PoliceHover>();
            script.Attack();
        }

        /*
        if(hasShootAnimation) {
            GameObject animation = Instantiate(shootAnimation, shootAnimationHolder.transform.position, shootAnimationHolder.transform.rotation);
            animation.transform.localScale = new Vector3(-1, 1, 1);
            Destroy(animation, animation.GetComponentInChildren<Animator>().GetCurrentAnimatorStateInfo(0).length); 
            animation.transform.parent = gameObject.transform;
        }
        */

    }

    public void Death() {
        if(dead) return;
        dead = true;
        animator.SetTrigger("Death");
        GameObject animation = Instantiate(deathEffectPrefab, transform.position, transform.rotation);
        animation.transform.parent = transform;
        deathAudioSource.Play();
        Destroy(animation, animation.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).length);
        Destroy(gameObject, animation.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).length+1f);
    }

    public IEnumerator StartHitCooldown() {
        yield return new WaitForSeconds(0.1f);
        coolingDownHit = false;
    }

}
