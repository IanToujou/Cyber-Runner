using UnityEngine;
using System.Collections;

public class FightTriggerStart : MonoBehaviour {
    
    [SerializeField] private int fightZone;
    [SerializeField] private GameObject secondTrigger;
    [SerializeField] private GameObject[] enemyPrefabs;
    [SerializeField] private float[] spawnLocationY;

    private bool hasEntered;
    private int enemiesAlive;
    private ArrayList enemyList = new ArrayList();

    void Start() {
        hasEntered = false;
        enemiesAlive = 1;
    }

    void Update() {
        if(hasEntered) {
            int count = 0;
            foreach(GameObject enemy in enemyList) {
                if(enemy != null) count++;
            }
            enemiesAlive = count;
            if(count <= 0) secondTrigger.GetComponent<FightTriggerEnd>().SetCanLeave(true);
        }
    }
    
    void OnTriggerEnter2D(Collider2D collider) {

        if(collider.CompareTag("Player")) {

            if(hasEntered) return;
            hasEntered = true;

            GameObject player = collider.gameObject;
            player.GetComponent<PlayerControls>().SetCurrentFightZone(fightZone);

            for (int i = 0; i < enemyPrefabs.Length; i++) {
                Vector3 location = new Vector3(GameManager.GetCameraHolder().transform.position.x+5f, GameManager.GetCameraHolder().transform.position.y+spawnLocationY[i], 0);
                GameObject enemy = Instantiate(enemyPrefabs[i], location, Quaternion.identity);
                enemyList.Add(enemy);
            }

        }
    }

    public void SetEnemiesAlive(int count) {
        this.enemiesAlive = count;
    }

}
