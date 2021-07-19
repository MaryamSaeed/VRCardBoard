using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BulletController : MonoBehaviour
{
    private void OnEnable()
    {
        Invoke("DisableObject", 4);
    }

    private void DisableObject()
    {
        gameObject.SetActive(false);
    }
}
