using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PanelBottom : MonoBehaviour
{
    [SerializeField] private Sprite[] sprites;

    private int currentSprite;

    void Start() {
        currentSprite = 0;
        StartCoroutine(Animate());
    }
    private IEnumerator Animate() {
        while(true) {
            if(currentSprite >= sprites.Length-1) currentSprite = 0;
            GetComponent<Image>().sprite = sprites[currentSprite];
            currentSprite++;
            yield return new WaitForSeconds(0.04f);
        }
    }

}
