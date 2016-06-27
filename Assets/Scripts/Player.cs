using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

    LifeSource lifeSource;
    CharacterController controller;

    private bool isLoad = false;
    private Vector3 moveDirection = Vector3.zero;

    public float speed = 20.0f;

    // Use this for initialization
    void Start () {
        lifeSource = new LifeSource();
        lifeSource.hp = 100f;
        lifeSource.mp = 0f;
        lifeSource.timeRatio  = 1.0f;
        lifeSource.gravity    = 20.0f;
        lifeSource.currStatus = 0;

        controller = GetComponent<CharacterController>();

        if (isLoad) {
            // load data from save file
        }

        lifeSource.initated = true;
	}
	
	// Update is called once per frame
	void Update () {
        if (controller.isGrounded) {
            moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            moveDirection = transform.TransformDirection(moveDirection);
            moveDirection *= speed;

            if (Input.GetButton("Jump"))
                moveDirection.y = speed;

        } else {
            print("not Grounded");
        }

        moveDirection.y -= speed * Time.deltaTime;
        controller.Move(moveDirection * Time.deltaTime);
    }
}
