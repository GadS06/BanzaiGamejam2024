using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shark : MonoBehaviour
{
    Cat cat;
    Rigidbody rb;
    public float rotationSpeed;
    public float acceleration;
    public float maxSpeed;

    // Start is called before the first frame update
    void Start()
    {
        cat = FindObjectOfType<Cat>();
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        // Calculate the direction towards the target
        Vector3 targetDirection = cat.transform.position - transform.position;

        // Normalize the direction to get a unit vector
        targetDirection.Normalize();

        // Calculate the desired velocity based on the target direction and max speed
        Vector3 desiredVelocity = targetDirection * maxSpeed;

        // Calculate the velocity change needed to reach the desired velocity
        Vector3 velocityChange = desiredVelocity - rb.velocity;

        // Apply acceleration to gradually change the velocity towards the desired velocity
        Vector3 accelerationVector = velocityChange.normalized * acceleration;
        rb.AddForce(accelerationVector, ForceMode.Acceleration);



        // Get the velocity of the Rigidbody
        Vector3 velocity = rb.velocity;

        // Check if the Rigidbody is moving (not stationary)
        if (velocity.magnitude > 0.1f)
        {
            // Calculate the rotation angle based on the velocity direction
            Quaternion targetRotation = Quaternion.LookRotation(velocity.normalized);

            // Smoothly rotate the Rigidbody towards the target rotation
            rb.MoveRotation(Quaternion.RotateTowards(transform.rotation, targetRotation, Time.deltaTime * rotationSpeed));
        }
    }
}
