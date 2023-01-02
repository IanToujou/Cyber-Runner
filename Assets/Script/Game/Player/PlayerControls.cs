using System.Collections;
using UnityEngine;

public class PlayerControls : MonoBehaviour {

    [SerializeField] private GameObject weapon;
    [SerializeField] private GameObject deathEffectPrefab;
    [SerializeField] private float speed;
    [SerializeField] private int maxHealth, maxShield, minLane, maxLane;

    private int health, shield, currentLane, currentFightZone;
    private float lerpValue;
    private Rigidbody2D rigidBody;
    private GameObject currentWeapon;
    private bool coolingDownHit, dead;
    private Animator animator;
    private AudioSource audioSource;

    void Start() {

        health = maxHealth;
        shield = maxShield;
        currentLane = 0;
        currentFightZone = 0;
        lerpValue = 0;
        coolingDownHit = false;
        dead = false;

        if(weapon != null) {
            SetWeapon(weapon);
        }

        rigidBody = gameObject.GetComponent<Rigidbody2D>();
        animator = GetComponentInChildren<Animator>();
        audioSource = GetComponent<AudioSource>();

    }

    void Update() {
        
        if(Input.GetKeyDown(KeyCode.H)) {
            Hurt(5);
        }

        //Shield and health fix for future usage.
        if(health < 0) health = 0;
        if(shield < 0) shield = 0;

        //Death and health check
        if(dead) return;
        if(health <= 0) Death();

        if(currentLane > maxLane || currentLane < minLane) Death();

        if(Input.GetKeyDown(KeyCode.W) && currentLane < maxLane) {
            currentLane += 1;
        } else if(Input.GetKeyDown(KeyCode.S) && currentLane > minLane) {
            currentLane -= 1;
        }

        float y = -2.15f + currentLane;
        Vector3 newPosition = new Vector3(transform.position.x, y, transform.position.z);

        if (lerpValue < 0.2) {
             lerpValue += Time.deltaTime / 5;
             transform.position = Vector3.Lerp(transform.position, newPosition, lerpValue);
        } else {
             lerpValue = 0;
        }

        if(currentWeapon != null) {
            if(Input.GetKey(KeyCode.Space)) {
                Weapon weapon = currentWeapon.GetComponent<Weapon>();
                weapon.Shoot();
            } else if(Input.GetKeyDown(KeyCode.R)) {
                Weapon weapon = currentWeapon.GetComponent<Weapon>();
                weapon.Reload();
            }
        }

    }

    public void FixedUpdate() {
        if(dead) {
            rigidBody.AddForce(-1 * rigidBody.velocity);
            return;
        }
        rigidBody.velocity = new Vector2(10 * speed, rigidBody.velocity.y);
    }

    void OnTriggerEnter2D(Collider2D collider) {
        if(collider.CompareTag("EnemyBullet")) {
            if(coolingDownHit) return;
            coolingDownHit = true;
            StartCoroutine(StartHitCooldown());
            Hurt(collider.gameObject);
        } else if(collider.CompareTag("Enemy")) {
            if(coolingDownHit) return;
            coolingDownHit = true;
            StartCoroutine(StartHitCooldown());
            Death();
        }  else if(collider.CompareTag("Hole")) {
            if(coolingDownHit) return;
            coolingDownHit = true;
            StartCoroutine(StartHitCooldown());
            Death();
        } else if(collider.CompareTag("Bomb")) {
            if(currentLane != collider.gameObject.GetComponent<EntityBomb>().GetLaneToBomb()) return;
            if(coolingDownHit) return;
            coolingDownHit = true;
            StartCoroutine(StartHitCooldown());
            Hurt(10);
        }
    }

    public void Death() {
        dead = true;
        GetComponentInChildren<SpriteRenderer>().enabled = false;
        RemoveWeapon();
        GameObject animation = Instantiate(deathEffectPrefab, transform.position, transform.rotation);
        animation.transform.parent = transform;
        audioSource.Play();
        Destroy(animation, animation.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).length);
        StartCoroutine(StartDeathScreenCooldown());
        GameManager.GetMusicManager().PlaySong(0);
    }

    public bool IsDead() {
        return dead;
    }

    public void Hurt(GameObject bullet) {
        if(dead) return;
        if(shield > 0) {
            shield -= bullet.GetComponent<Bullet>().GetDamage();
            animator.SetTrigger("ShieldHurt");
        } else {
            health -= bullet.GetComponent<Bullet>().GetDamage();
            animator.SetTrigger("Hurt");
        }
        Destroy(bullet);
    }

    public void Hurt(int damage) {
        if(dead) return;
        if(shield > 0) {
            shield -= damage;
            animator.SetTrigger("ShieldHurt");
        } else {
            health -= damage;
            animator.SetTrigger("Hurt");
        }
    }

    public float GetSpeed() {
        return speed;
    }

    public void SetSpeed(float speed) {
        this.speed = speed;
    }

    public int GetHealth() {
        return health;
    }

    public void SetHealth(int health) {
        this.health = health;
    }

    public int GetShield() {
        return shield;
    }

    public void SetShield(int shield) {
        this.shield = shield;
    }

    public void SetMinLane(int lane) {
        this.minLane = lane;
    }

    public int GetMinLane() {
        return minLane;
    }

    public void SetMaxLane(int lane) {
        this.maxLane = lane;
    }

    public int GetMaxLane() {
        return maxLane;
    }

    public void SetCurrentLane(int lane) {
        this.currentLane = lane;
    }
    
    public int GetCurrentLane() {
        return currentLane;
    }

    public void SetCurrentFightZone(int fightZone) {
        this.currentFightZone = fightZone;
    }
    
    public int GetCurrentFightZone() {
        return currentFightZone;
    }

    public bool HasWeapon() {
        return (currentWeapon != null);
    }

    public Weapon GetWeapon() {
        if(!HasWeapon()) return null;
        return currentWeapon.GetComponent<Weapon>();
    }

    public void RemoveWeapon() {
        if(HasWeapon()) {
            Destroy(currentWeapon);
        }
    }

    public void SetWeapon(GameObject weapon) {
        RemoveWeapon();
        currentWeapon = Instantiate(weapon, new Vector3(transform.position.x+0.46f, transform.position.y+0.1f, transform.position.z-0.2f), Quaternion.identity);
        currentWeapon.transform.parent = gameObject.transform;
    }

    public IEnumerator StartHitCooldown() {
        yield return new WaitForSeconds(0.1f);
        coolingDownHit = false;
    }

    public IEnumerator StartDeathScreenCooldown() {
        yield return new WaitForSeconds(0.2f);
        IngameUI.SetActiveCanvas(IngameUI.DEATH);
    }

}
