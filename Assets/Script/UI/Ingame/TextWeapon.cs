using TMPro;
using UnityEngine;

public class TextWeapon : MonoBehaviour {
    private GameObject player;

    void Update() {
        player = GameManager.GetPlayer();
        PlayerControls playerScript = player.GetComponent<PlayerControls>();
        if(!playerScript.HasWeapon()) return;
        Weapon weapon = playerScript.GetWeapon();
        gameObject.GetComponent<TextMeshProUGUI>().text = weapon.GetWeaponName().ToUpper();
    }
    
}
