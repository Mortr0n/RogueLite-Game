using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMove : MonoBehaviour
{
    Rigidbody2D rgbd2d;

    Vector3 movementVector;

    [SerializeField] float playerSpeed =  3f;

    Animate animate;

    // Start is called before the first frame update
    private void Awake()
    {
        rgbd2d = GetComponent<Rigidbody2D>();
        movementVector = new Vector3();
        animate = GetComponent<Animate>();
    }

    // Update is called once per frame
    void Update()
    {
        movementVector.x = Input.GetAxisRaw("Horizontal");
        movementVector.y = Input.GetAxisRaw("Vertical");

        movementVector *= playerSpeed;

        animate.horizontal = movementVector.x;
        rgbd2d.velocity = movementVector;
    }
}
