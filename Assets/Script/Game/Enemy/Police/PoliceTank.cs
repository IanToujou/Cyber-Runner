using System.Collections;
using UnityEngine;

public class PoliceTank : MonoBehaviour {
    
    [SerializeField] private float attackCooldown;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform bulletHolder;
    [SerializeField] private AudioSource shootAudioSource;

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

    }

    public IEnumerator AttackCooldown() {
        yield return new WaitForSeconds(attackCooldown);
        coolingDownAttack = false;
    }

}
