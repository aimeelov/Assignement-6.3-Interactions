using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class FirstPersonMovement : MonoBehaviour
{
    // Player's movement parameters
    public Vector3 direction;
    public float speed;

    public Rigidbody rb; // the player's rigidbody

    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    // All physics calculations happen in FixedUpdate
    void FixedUpdate()
    {
        // transform.Translate(direction * speed * Time.deltaTime);
        // make world direction into local direction & move using physics
        Vector3 localDirection = transform.TransformDirection(direction);
        rb.MovePosition(rb.position + (direction * speed * Time.deltaTime));
    }

    // onPlayerMove event handler 
    public void OnPlayerMove(InputValue value)
    {
        // A vector with x and y components corresponding to the player's WASD and arrow inputs
        // Both components are in the range [-1, 1]
        Vector2 inputVector = value.Get<Vector2>();
       
       // move in the xZ-plane
        direction.x = inputVector.x;
        direction.z = inputVector.y;

    }
}
