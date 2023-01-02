using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class PanelDeathBlack : MonoBehaviour {

    private Image image;
    private float alpha;

    void Start() {
        image = GetComponent<Image>();
        alpha = 0;
        StartCoroutine(AnimatePanel());
    }

    private IEnumerator AnimatePanel() {
        while(image.color.a < 1) {
            Color color = image.color;
            color.a = alpha;
            image.color = color;
            alpha += 0.01f;
            yield return new WaitForSeconds(0.01f);
        }
    }

}
