using System.Collections;
using UnityEngine;

public class PoliceHelicopter : MonoBehaviour {
    
    [SerializeField] private float attackCooldown;
    [SerializeField] private GameObject bombPrefab;
    [SerializeField] private GameObject markerPrefab;
    [SerializeField] private Transform dropLocation;
    [SerializeField] private AudioSource dropAudioSource;

    private Animator animator;
    private Rigidbody2D rigidBody;
    private bool coolingDownAttack;

    void Start() {
        animator = GetComponentInChildren<Animator>();
        rigidBody = GetComponent<Rigidbody2D>();
        coolingDownAttack = false;
    }

    public void Attack() {
        if(coolingDownAttack) return;
        StartCoroutine(AttackSequence());
        StartCoroutine(AttackCooldown());
    }

    public IEnumerator AttackSequence() {

        if(coolingDownAttack) yield break;
        coolingDownAttack = true;

        rigidBody.velocity = new Vector2(-7f, 0f);
        yield return new WaitForSeconds(1.4f);

        rigidBody.velocity = new Vector2(0f, 0f);
        yield return new WaitForSeconds(1f);
        
        PlayerControls player = GameManager.GetPlayer().GetComponent<PlayerControls>();
        int laneToBomb = player.GetCurrentLane();
        float y = -2.4f + laneToBomb;
        GameObject marker = Instantiate(markerPrefab, new Vector3(transform.position.x, y, 0f), Quaternion.identity);
        marker.transform.parent = GameManager.getCameraHolder().transform;

        animator.SetTrigger("Attack");
        yield return new WaitForSeconds(0.5f);

        GameObject bomb = Instantiate(bombPrefab, dropLocation.position, Quaternion.identity);
        bomb.transform.parent = GameManager.getCameraHolder().transform;
        bomb.GetComponent<EntityBomb>().SetLaneToBomb(laneToBomb);
        bomb.GetComponent<Rigidbody2D>().velocity = new Vector2(0f, -1f);
        dropAudioSource.Play();

        yield return new WaitForSeconds(1.5f);
        Destroy(marker);

        rigidBody.velocity = new Vector2(7f, 0f);
        yield return new WaitForSeconds(1.4f);
        rigidBody.velocity = new Vector2(0f, 0f);

    }

    public IEnumerator AttackCooldown() {
        yield return new WaitForSeconds(attackCooldown);
        coolingDownAttack = false;
    }

}
