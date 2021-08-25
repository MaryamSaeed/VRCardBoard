using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotCOntroller : MonoBehaviour
{
    private Rigidbody robotRigidBody;
    public float forceFactor = 5;
    Vector3 rightrotation = new Vector3(0, 90, 0);
    private enum facingDirection { forward, backword, left, right };
    private facingDirection currentfacing = facingDirection.forward;
    // Start is called before the first frame update
    private void Start()
    {
        robotRigidBody = GetComponent<Rigidbody>();
    }
    // Update is called once per frame
    private void Update()
    {
        robotRigidBody.velocity = Vector3.zero;
        if (Input.GetKey(KeyCode.W) || InputManager.Instance.getButton(InputManager.Instance.triangle))
        {

            //move forward
            robotRigidBody.AddForce(0, 0, forceFactor);
            if (currentfacing != facingDirection.forward)
            {
                if (currentfacing == facingDirection.right)
                    transform.localEulerAngles = transform.localEulerAngles + (rightrotation * -1);
                else if (currentfacing == facingDirection.left)
                    transform.localEulerAngles = transform.localEulerAngles + rightrotation;
                else if (currentfacing == facingDirection.backword)
                    transform.localEulerAngles = transform.localEulerAngles + (rightrotation * -2);
                currentfacing = facingDirection.forward;
            }
        }
        if (Input.GetKey(KeyCode.S) || InputManager.Instance.getButton(InputManager.Instance.cross))
        {
            //move backword
            robotRigidBody.AddForce(0, 0, -forceFactor);
            if (currentfacing != facingDirection.backword)
            {
                if (currentfacing == facingDirection.left)
                    transform.localEulerAngles = transform.localEulerAngles + (rightrotation * -1);
                else if (currentfacing == facingDirection.right)
                    transform.localEulerAngles = transform.localEulerAngles + rightrotation;
                else if (currentfacing == facingDirection.forward)
                    transform.localEulerAngles = transform.localEulerAngles + (rightrotation * 2);
                currentfacing = facingDirection.backword;
            }
        }
        if (Input.GetKey(KeyCode.A) || InputManager.Instance.getButton(InputManager.Instance.square))
        {
            //move Left
            robotRigidBody.AddForce(-forceFactor, 0, 0);
            if (currentfacing != facingDirection.right)
            {
                if (currentfacing == facingDirection.forward)
                    transform.localEulerAngles = transform.localEulerAngles + (rightrotation * -1);
                else if (currentfacing == facingDirection.backword)
                    transform.localEulerAngles = transform.localEulerAngles + rightrotation;
                else if(currentfacing == facingDirection.left)
                    transform.localEulerAngles = transform.localEulerAngles + (rightrotation * 2);
                currentfacing = facingDirection.right;
            }
        }
        if (Input.GetKey(KeyCode.D) || InputManager.Instance.getButton(InputManager.Instance.circler))
        {
            //move Right
            robotRigidBody.AddForce(forceFactor, 0, 0);
            if (currentfacing != facingDirection.left)
            {
                if (currentfacing == facingDirection.forward)
                    transform.localEulerAngles = transform.localEulerAngles + rightrotation;
                else if (currentfacing == facingDirection.backword)
                    transform.localEulerAngles = transform.localEulerAngles + (rightrotation * -1);
                else if (currentfacing == facingDirection.right)
                    transform.localEulerAngles = transform.localEulerAngles + (rightrotation * -2);
                currentfacing = facingDirection.left;
            }
        }
        Debug.Log(robotRigidBody.velocity.normalized);
    }

}
