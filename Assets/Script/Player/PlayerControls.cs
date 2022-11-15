using UnityEngine;

public class PlayerControls : MonoBehaviour {

    [SerializeField] private GameObject bulletPrefab;

    private int currentLane;
    private int minLane;
    private int maxLane;
    private float lerpValue;

    void Start() {
        currentLane = 0;
        minLane = -1;
        maxLane = 2;
        lerpValue = 0;
    }

    void Update() {

        if(Input.GetKeyDown(KeyCode.W) && currentLane < maxLane) {
            currentLane += 1;
        } else if(Input.GetKeyDown(KeyCode.S) && currentLane > minLane) {
            currentLane -= 1;
        }

        float y = -2.2f + currentLane;
        Vector3 newPosition = new Vector3(transform.position.x, y, transform.position.z);

        if (lerpValue < 0.2) {
             lerpValue += Time.deltaTime / 5;
             transform.position = Vector3.Lerp(transform.position, newPosition, lerpValue);
        } else {
             lerpValue = 0;
        }

        if(Input.GetKeyDown(KeyCode.Space)) {
            Instantiate(bulletPrefab, transform.position, Quaternion.identity);
        }

    }

    public void setMinLane(int lane) {
        this.minLane = lane;
    }

    public void setMaxLane(int lane) {
        this.maxLane = lane;
    }

    public void setCurrentLane(int lane) {
        this.currentLane = lane;
    }

}
