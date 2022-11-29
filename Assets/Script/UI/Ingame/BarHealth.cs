using UnityEngine;
using UnityEngine.UI;

public class BarHealth : MonoBehaviour {

    private Slider slider;

    void Start() {
        slider = GetComponent<Slider>();
    }

    void Update() {
        slider.value = GameManager.GetPlayer().GetComponent<PlayerControls>().GetHealth();
    }
    
}
