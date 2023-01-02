using UnityEngine;
using System.Collections;
using TMPro;

public class TextErrorBottom : MonoBehaviour {
    
    void Start() {
        StartCoroutine(AnimateText());
    }

    private IEnumerator AnimateText() {
        while(true) {
            gameObject.GetComponent<TextMeshProUGUI>().alpha = 0;
            yield return new WaitForSeconds(0.5f);
            gameObject.GetComponent<TextMeshProUGUI>().alpha = 1;
            yield return new WaitForSeconds(0.5f);
        }
    }

}
