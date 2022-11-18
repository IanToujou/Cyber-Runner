using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour {
    
    [SerializeField] private string name;
    [SerializeField] private GameObject bullet;
    [SerializeField] private GameObject shootAnimation;
    [SerializeField] private float cooldown;
    [SerializeField] private int magazineSize;
    [SerializeField] private float reloadTime;

    private int ammo;
    private bool coolingDown;

    void Start() {

    }

    public void Shoot() {
        if(coolingDown) return;
        coolingDown = true;
        StartCooldown();
    }

    public IEnumerator StartCooldown() {
        yield return new WaitForSeconds(cooldown);
        coolingDown = false;
    }

}
