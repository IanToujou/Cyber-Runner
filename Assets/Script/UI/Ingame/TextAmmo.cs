using TMPro;
using UnityEngine;

public class TextAmmo : MonoBehaviour {

    private GameObject player;

    void Update() {
        player = GameManager.GetPlayer();
        PlayerControls playerScript = player.GetComponent<PlayerControls>();
        if(!playerScript.HasWeapon()) return;
        Weapon weapon = playerScript.GetWeapon();
        if(weapon.IsCoolingDownReload()) {
            gameObject.GetComponent<TextMeshProUGUI>().text = "Reloading...";
        } else {
            gameObject.GetComponent<TextMeshProUGUI>().text = weapon.GetAmmo() + "/" + weapon.GetMagazineSize();
        }
    }
}
