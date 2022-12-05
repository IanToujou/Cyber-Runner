using UnityEngine;

public class EntityBomb : MonoBehaviour {
    
    [SerializeField] private GameObject deathEffectPrefab;

    private bool dead;
    private AudioSource audioSource;
    private Rigidbody2D rigidBody;
    private int laneToBomb;

    void Start() {
        dead = false;
        audioSource = GetComponent<AudioSource>();
        rigidBody = GetComponent<Rigidbody2D>();
        laneToBomb = 0;
    }

    void OnTriggerEnter2D(Collider2D collider) {
        if(collider.CompareTag("Player")) {
            if(dead) return;
            if(laneToBomb != GameManager.GetPlayer().GetComponent<PlayerControls>().GetCurrentLane()) return;
            dead = true;
            rigidBody.constraints = RigidbodyConstraints2D.FreezeAll;
            rigidBody.velocity = new Vector2(0f, 0f);
            GameObject animation = Instantiate(deathEffectPrefab, transform.position, transform.rotation);
            animation.transform.parent = transform;
            audioSource.Play();
            Destroy(animation, animation.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).length);
            Destroy(gameObject, animation.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).length);
        } else if(collider.CompareTag("DropMarker")) {
            dead = true;
            rigidBody.constraints = RigidbodyConstraints2D.FreezeAll;
            rigidBody.velocity = new Vector2(0f, 0f);
            GameObject animation = Instantiate(deathEffectPrefab, transform.position, transform.rotation);
            animation.transform.parent = transform;
            audioSource.Play();
            GetComponentInChildren<SpriteRenderer>().enabled = false;
            Destroy(animation, animation.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).length);
            Destroy(gameObject, animation.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).length);
        }
    }

    public void SetLaneToBomb(int laneToBomb) {
        this.laneToBomb = laneToBomb;
    }

    public int GetLaneToBomb() {
        return laneToBomb;
    }

}
