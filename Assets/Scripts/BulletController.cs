using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class BulletController : MonoBehaviour
{
    private Rigidbody bulletRigidBody;
    private void OnEnable()
    {
        if (bulletRigidBody == null)
            bulletRigidBody = GetComponent<Rigidbody>();
        Invoke("DisableObject", 4);
    }
    /// <summary>
    /// invoked after a certain interval of time to
    /// reset the objects velocity and diables the gameobject
    /// </summary>
    private void DisableObject()
    {
        bulletRigidBody.velocity = Vector3.zero;
        gameObject.SetActive(false);
    }
}
