using UnityEngine;

public class PlayerControls : MonoBehaviour {

    [SerializeField] private GameObject currentWeapon;

    private int currentLane;
    private int minLane;
    private int maxLane;
    private float lerpValue;
    private GameObject loadedWeapon;

    void Start() {
        currentLane = 0;
        minLane = -1;
        maxLane = 2;
        lerpValue = 0;

        if(currentWeapon != null) {
            loadedWeapon = Instantiate(currentWeapon, new Vector3(transform.position.x+0.46f, transform.position.y+0.1f, transform.position.z-0.2f), Quaternion.identity);
            loadedWeapon.transform.parent = gameObject.transform;
        }

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

        if(loadedWeapon != null) {
            
            if(Input.GetKey(KeyCode.Space)) {

                Weapon weapon = loadedWeapon.GetComponent<Weapon>();
                weapon.Shoot();

            } else if(Input.GetKeyDown(KeyCode.R)) {

                Weapon weapon = loadedWeapon.GetComponent<Weapon>();
                weapon.Reload();

            }

        }

    }

    public void SetMinLane(int lane) {
        this.minLane = lane;
    }

    public void SetMaxLane(int lane) {
        this.maxLane = lane;
    }

    public void SetCurrentLane(int lane) {
        this.currentLane = lane;
    }

    public bool HasWeapon() {
        return (loadedWeapon != null);
    }

    public Weapon GetWeapon() {
        if(!HasWeapon()) return null;
        return loadedWeapon.GetComponent<Weapon>();
    }

}
