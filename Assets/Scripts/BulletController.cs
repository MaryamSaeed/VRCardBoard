using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BulletController : MonoBehaviour
{
    private Rigidbody bulletRigidBody;
    private void OnEnable()
    {
        if (bulletRigidBody == null)
            bulletRigidBody = GetComponent<Rigidbody>();
        Invoke("DisableObject", 4);
    }

    private void DisableObject()
    {
        bulletRigidBody.velocity = Vector3.zero;
        gameObject.SetActive(false);
    }
}
