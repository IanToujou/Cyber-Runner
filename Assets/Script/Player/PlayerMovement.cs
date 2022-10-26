using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
    
    [SerializeField] private float speed;
    private Rigidbody2D rigidBody;

    public void Start() {
        rigidBody = gameObject.GetComponent<Rigidbody2D>();
    }

    public void FixedUpdate() {
        rigidBody.velocity = new Vector2(10 * speed, rigidBody.velocity.y);
    }

}
