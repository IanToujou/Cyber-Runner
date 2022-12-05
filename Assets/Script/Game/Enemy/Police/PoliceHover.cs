using System.Collections;
using UnityEngine;

public class PoliceHover : MonoBehaviour {
    
    [SerializeField] private float attackCooldown;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform bulletHolder;
    [SerializeField] private AudioSource shootAudioSource;
    [SerializeField] private GameObject shootAnimationPrefab;
    [SerializeField] private Transform shootAnimationHolder;

    private Animator animator;
    private bool coolingDownAttack;

    void Start() {
        animator = GetComponentInChildren<Animator>();
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

        animator.SetTrigger("Attack");
        GameObject shotBullet = Instantiate(bulletPrefab, bulletHolder.position, Quaternion.identity);
        shotBullet.GetComponent<Bullet>().SetOwnedByPlayer(false);
        shootAudioSource.Play();

        GameObject animation = Instantiate(shootAnimationPrefab, shootAnimationHolder.transform.position, shootAnimationHolder.transform.rotation);
        animation.transform.localScale = new Vector3(-1, 1, 1);
        Destroy(animation, animation.GetComponentInChildren<Animator>().GetCurrentAnimatorStateInfo(0).length); 
        animation.transform.parent = gameObject.transform;

    }

    public IEnumerator AttackCooldown() {
        yield return new WaitForSeconds(attackCooldown);
        coolingDownAttack = false;
    }

}
