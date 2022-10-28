using UnityEngine;

public class PlayerMovement : MonoBehaviour {
    
    [SerializeField] private float speed;
    private Rigidbody2D rigidBody;
    private float z;

    public void Start() {
        z = 0;
        rigidBody = gameObject.GetComponent<Rigidbody2D>();
    }

    public void FixedUpdate() {
        rigidBody.velocity = new Vector2(10 * speed, rigidBody.velocity.y);
    }

}
