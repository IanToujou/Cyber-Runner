using System.Collections;
using UnityEngine;

public class Bullet : MonoBehaviour {
    
    [SerializeField] private bool ownedByPlayer;
    [SerializeField] private float speed;
    [SerializeField] private int damage;

    private GameObject player;
    private Rigidbody2D rigidBody;
    private Vector3 mousePosition;

    void Start() {
        rigidBody = GetComponent<Rigidbody2D>();
        player = GameManager.GetPlayer();
        if(ownedByPlayer) {
            gameObject.transform.position = new Vector3(player.transform.position.x+1f, player.transform.position.y, -0.1f);
            gameObject.tag = "PlayerBullet";
            mousePosition = Input.mousePosition;

            Vector3 position = GameManager.GetCameraHolder().GetComponentInChildren<Camera>().ScreenToWorldPoint(mousePosition);
            Vector3 direction = position - transform.position;
            Vector3 rotation = transform.position - position;
            rigidBody.velocity = new Vector2(direction.x, direction.y).normalized * speed * 10;
            float rot = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0, 0, rot);
            transform.parent = GameManager.GetCameraHolder().transform;

        } else {
            gameObject.tag = "EnemyBullet";
        }
        StartCoroutine(StartDespawnDelay());
    }

    void FixedUpdate() {
        if(ownedByPlayer) {
            
        } else {
            rigidBody.velocity = new Vector2(-10 * speed, rigidBody.velocity.y);
        }
    }

    private IEnumerator StartDespawnDelay() {
        yield return new WaitForSeconds(5);
        Destroy(gameObject);
    }

    public void SetOwnedByPlayer(bool ownedByPlayer) {
        this.ownedByPlayer = ownedByPlayer;
    }

    public bool IsOwnedByPlayer() {
        return ownedByPlayer;
    }

    public void SetSpeed(float speed) {
        this.speed = speed;
    }

    public float GetSpeed() {
        return speed;
    }

    public void SetDamage(int damage) {
        this.damage = damage;
    }

    public int GetDamage() {
        return damage;
    }

}
