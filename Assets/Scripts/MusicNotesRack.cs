using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MusicNotesRack : MonoBehaviour
{
    public UnityEvent StartMacarinaDance;
    private Animator rackAnimator;
    private int musicNotescount = 0;
    private int musicNotesTarget = 3;
    // Start is called before the first frame update
    void Start()
    {
        rackAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("MusicNote"))
        {
            other.gameObject.SetActive(false);
            musicNotescount++;
            if (musicNotescount == musicNotesTarget)
            {
                rackAnimator.SetTrigger("play");
                musicNotescount = 0;
            }
        }
    }
    public void OnRackClosed()
    {
        StartMacarinaDance.Invoke();
    }
}
