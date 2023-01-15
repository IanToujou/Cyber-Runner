using System.Collections;
using UnityEngine;

public class IngameUIEntry : MonoBehaviour {

    void Start() {
        StartCoroutine(StartDelay());
    }

    public IEnumerator StartDelay() {
        yield return new WaitForSeconds(2f);
        IngameUI.SetActiveCanvas(IngameUI.MAIN);
    }

}
