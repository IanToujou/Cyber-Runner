using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonStart : MonoBehaviour {
    
    public void ButtonClick() {
        SceneManager.LoadScene("SceneZoneOne");
    }

}
