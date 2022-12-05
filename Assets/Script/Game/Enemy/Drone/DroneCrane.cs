using UnityEngine;

public class DroneCrane : MonoBehaviour
{

    private Animator animator;

    // Start is called before the first frame update
    void Start() {
       animator = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.H)) {
            animator.SetBool("Walking", true);
        } else if(Input.GetKeyDown(KeyCode.J)) {
            animator.SetBool("Walking", false);
        }

        if(Input.GetKeyDown(KeyCode.K)) {
            animator.SetTrigger("Land");
        } else if(Input.GetKeyDown(KeyCode.L)) {
            animator.SetTrigger("Start");
        }

        if(Input.GetKeyDown(KeyCode.T)) {
            animator.SetTrigger("Death");
        }

    }
}
