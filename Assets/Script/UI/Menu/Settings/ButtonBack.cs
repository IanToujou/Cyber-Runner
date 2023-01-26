using UnityEngine;

public class ButtonBack : MonoBehaviour {

    public void ButtonClick() {
        MenuUI.SetActiveCanvas(MenuUI.MAIN);
    }

}
