using UnityEngine;

public class ButtonSettings : MonoBehaviour
{
    public void ButtonClick() {
        MenuUI.SetActiveCanvas(MenuUI.SETTINGS);
    }

}
