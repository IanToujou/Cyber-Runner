using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour {

    private bool shaking;

    void Start() {
        shaking = false;
    }

    void FixedUpdate() {
        if(!shaking) {
            shaking = true;
            StartCoroutine(Shake(10f, 0.2f));
        }
    }
    
    public IEnumerator Shake(float duration, float magnitude) {
        Vector3 originalPos = transform.localPosition;
        float elapsed = 0f;
        while(elapsed < duration) {
            shaking = true;
            float x = Random.Range(-1f, 1f) * 0.1f * magnitude;
            float y = Random.Range(-1f, 1f) * 0.1f * magnitude;
            transform.localPosition = new Vector3(x, y, originalPos.z);
            elapsed += Time.deltaTime;
            yield return null;
        }
        transform.localPosition = originalPos;
        shaking = false;
    }

}
