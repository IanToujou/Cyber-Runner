using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ImageDeathSkull : MonoBehaviour {
    
    [SerializeField] private Sprite[] sprites;

    private int currentSprite;

    void Start() {
        currentSprite = 0;
        StartCoroutine(Animate());
    }
    private IEnumerator Animate() {
        while(currentSprite < sprites.Length) {
            GetComponent<Image>().sprite = sprites[currentSprite];
            currentSprite++;
            yield return new WaitForSeconds(0.06f);
        }
        currentSprite = sprites.Length-1;
        while(true) {
            yield return new WaitForSeconds(1f);
            GetComponent<Image>().sprite = sprites[currentSprite-1];
            yield return new WaitForSeconds(1f);
            GetComponent<Image>().sprite = sprites[currentSprite];
        }
    }

}
