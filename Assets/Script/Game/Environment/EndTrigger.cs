using UnityEngine;
using UnityEngine.SceneManagement;

public class EndTrigger : MonoBehaviour {
    
    [SerializeField] private string sceneName;

    void OnTriggerEnter2D(Collider2D collider) {
        if(collider.CompareTag("Player")) {
            SceneManager.LoadScene(sceneName);
        }
    }

}
