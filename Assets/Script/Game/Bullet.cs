using System.Collections;
using UnityEngine;

public class Bullet : MonoBehaviour {
    
    [SerializeField] private bool ownedByPlayer;
    [SerializeField] private float speed;
    [SerializeField] private float damage;

    private GameObject player;
    private Rigidbody2D rigidBody;

    void Start() {
        rigidBody = GetComponent<Rigidbody2D>();
        player = GameManager.GetPlayer();
        if(ownedByPlayer) gameObject.transform.position = new Vector3(player.transform.position.x+1f, player.transform.position.y, -0.1f);
        StartCoroutine(StartDespawnDelay());
    }

    void FixedUpdate() {
        if(ownedByPlayer) {
            rigidBody.velocity = new Vector2(10 * speed, rigidBody.velocity.y);
        }
    }

    private IEnumerator StartDespawnDelay() {
        yield return new WaitForSeconds(5);
        Destroy(gameObject);
    }

}
