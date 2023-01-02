using System.Collections;
using UnityEngine;

public class Weapon : MonoBehaviour {
    
    [SerializeField] private string weaponName;
    [SerializeField] private GameObject bullet;
    [SerializeField] private GameObject shootAnimation;
    [SerializeField] private GameObject animationHolder;
    [SerializeField] private float shotCooldown;
    [SerializeField] private int magazineSize;
    [SerializeField] private float reloadTime;

    private int ammo;
    private bool coolingDownShot;
    private bool coolingDownReload;

    void Start() {
        ammo = magazineSize;
        coolingDownShot = false;
        coolingDownReload = false;
    }

    void FixedUpdate() {
        Vector3 position = GameManager.GetCameraHolder().GetComponentInChildren<Camera>().ScreenToWorldPoint(Input.mousePosition);
        Vector3 rotation = transform.position - position;
        float rot = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, rot + 180f);
    }

    public void Shoot() {
        if(ammo <= 0) {
            Reload();
            return;
        }
        if(coolingDownShot) return;
        if(coolingDownReload) return;
        coolingDownShot = true;
        StartCoroutine(StartShotCooldown());
        GameObject shotBullet = Instantiate(bullet, transform.position, Quaternion.identity);
        shotBullet.GetComponent<Bullet>().SetOwnedByPlayer(true);
        GameObject animation = Instantiate(shootAnimation, animationHolder.transform.position, animationHolder.transform.rotation);
        Destroy(animation, animation.GetComponentInChildren<Animator>().GetCurrentAnimatorStateInfo(0).length); 
        animation.transform.parent = gameObject.transform;
        ammo--;
        GetComponent<AudioSource>().Play();
    }

    public void Reload() {
        if(coolingDownReload) return;
        if(ammo >= magazineSize) return;
        coolingDownReload = true;
        StartCoroutine(StartReloadCooldown());
    }

    public IEnumerator StartShotCooldown() {
        yield return new WaitForSeconds(shotCooldown);
        coolingDownShot = false;
    }

    public IEnumerator StartReloadCooldown() {
        yield return new WaitForSeconds(reloadTime);
        coolingDownReload = false;
        ammo = magazineSize;
    }

    public string GetWeaponName() {
        return weaponName;
    }

    public float GetShotCooldown() {
        return shotCooldown;
    }

    public int GetMagazineSize() {
        return magazineSize;
    }

    public float GetReloadTime() {
        return reloadTime;
    }

    public float GetAmmo() {
        return ammo;
    }

    public bool IsCoolingDownShot() {
        return coolingDownShot;
    }

    public bool IsCoolingDownReload() {
        return coolingDownReload;
    }

}
