using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketMovement : MonoBehaviour
{

    float thrustAmount = 5f;
    Rigidbody rigidBody;



    // Use this for initialization
    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame



    void Update()
    {
        ProcessInput();
    }

    void ProcessInput()
    {
        if (Input.GetKey(KeyCode.Space))
        {

            rigidBody.AddForce(1, y: 100, z: 1);

        }

        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(Vector3.forward);

        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(Vector3.back);

        }

    }
}
