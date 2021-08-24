using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotCOntroller : MonoBehaviour
{
    private Rigidbody robotRigidBody;
    public float forceFactor= 5;
    // Start is called before the first frame update
    void Start()
    {
        robotRigidBody = GetComponent<Rigidbody>();
    }
    // Update is called once per frame
    void Update()
    {
        robotRigidBody.velocity = Vector3.zero;
        if (Input.GetKey(KeyCode.W))
        {
            //move forward
            robotRigidBody.AddRelativeForce(transform.forward *forceFactor);
        }
        if (Input.GetKey(KeyCode.S))
        {
            //move backword
            robotRigidBody.AddForce(transform.forward * -forceFactor);
        }
        if (Input.GetKey(KeyCode.A))
        {
            //move Left
            robotRigidBody.AddForce(-forceFactor*transform.right);
        }
        if (Input.GetKey(KeyCode.D))
        {
            //move Right
            robotRigidBody.AddForce(forceFactor*transform.right);
        }
    }
}
