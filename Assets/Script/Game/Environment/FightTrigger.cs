using UnityEngine;

public class FightTrigger : MonoBehaviour {
    
    [SerializeField] private int fightZone;
    [SerializeField] private bool isEnd;
    [SerializeField] private GameObject secondTrigger;
    [SerializeField] private GameObject[] enemyPrefabs;
    [SerializeField] private float[] spawnLocationY;
    
    void OnTriggerEnter2D(Collider2D collider) {
        if(collider.CompareTag("Player")) {
            GameObject player = collider.gameObject;
            if(isEnd) {
                player.transform.position = new Vector3(secondTrigger.transform.position.x, player.transform.position.y, player.transform.position.z);
                Debug.Log("End reached");
            } else {
                
                player.GetComponent<PlayerControls>().SetCurrentFightZone(fightZone);

                for (int i = 0; i < enemyPrefabs.Length; i++) {
                    Vector3 location = new Vector3(GameManager.GetCameraHolder().transform.position.x+5f, GameManager.GetCameraHolder().transform.position.y+spawnLocationY[i], 0);
                    Instantiate(enemyPrefabs[i], location, Quaternion.identity);
                }

            }
        }
    }

}
