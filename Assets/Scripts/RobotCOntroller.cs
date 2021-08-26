using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotCOntroller : MonoBehaviour
{
    public Transform objectHolder;
    public float forceFactor = 5;
    public LayerMask MusicNoteLayer;
    private Vector3 rightrotation = new Vector3(0, 90, 0);
    private Collider currentHolded;
    private enum facingDirection { forward, backword, left, right };
    private facingDirection currentfacing = facingDirection.forward;
    private float radius = 1;
    private Rigidbody robotRigidBody = null;
    // Start is called before the first frame update
    private void Start()
    {
        robotRigidBody = GetComponent<Rigidbody>();
    }
    // Update is called once per frame
    private void FixedUpdate()
    {
        MoveRobot();
        GrabMusicNote();
        ThroughNote();
    }
    private void MoveRobot()
    {
        robotRigidBody.velocity = Vector3.zero;
        if (Input.GetKey(KeyCode.W) || InputManager.Instance.getButton(InputManager.Instance.triangle))
        {
            //move forward
            robotRigidBody.AddForce(0, 0, forceFactor);
        }
        if (Input.GetKey(KeyCode.S) || InputManager.Instance.getButton(InputManager.Instance.cross))
        {
            //move backword
            robotRigidBody.AddForce(0, 0, -forceFactor);
        }
        if (Input.GetKey(KeyCode.A) || InputManager.Instance.getButton(InputManager.Instance.square))
        {
            //move Left
            robotRigidBody.AddForce(-forceFactor, 0, 0);
        }
        if (Input.GetKey(KeyCode.D) || InputManager.Instance.getButton(InputManager.Instance.circler))
        {
            //move Right
            robotRigidBody.AddForce(forceFactor, 0, 0);
        }
    }
    private void GrabMusicNote()
    {
        if (currentHolded == null)
        {
            if (InputManager.Instance.getButton(InputManager.Instance.R1))
            {
                Collider[] hitColliders = Physics.OverlapSphere(transform.localPosition, radius, MusicNoteLayer);
                if (hitColliders.Length > 0)
                {
                    hitColliders[0].attachedRigidbody.isKinematic = true;
                    hitColliders[0].attachedRigidbody.useGravity = false;
                    hitColliders[0].transform.parent = objectHolder.transform;
                    hitColliders[0].transform.localPosition = objectHolder.localPosition;
                    hitColliders[0].transform.localRotation = objectHolder.localRotation;
                    currentHolded = hitColliders[0];
                }
                else
                    Debug.Log("No overlapping objects where detected");
            }
        }
    }
    private void ThroughNote()
    {
        if (InputManager.Instance.getButton(InputManager.Instance.L1))
        {
            if (currentHolded != null)
            {
                currentHolded.attachedRigidbody.isKinematic = false;
                currentHolded.attachedRigidbody.useGravity = true;
                currentHolded.transform.parent = null;
                currentHolded = null;
            }
        }
    }
}
