using UnityEngine;
using UnityEngine.UI;

public class BarShield : MonoBehaviour {
    
    private Slider slider;

    void Start() {
        slider = GetComponent<Slider>();
    }

    void Update() {
        slider.value = GameManager.GetPlayer().GetComponent<PlayerControls>().GetShield();
    }

}
