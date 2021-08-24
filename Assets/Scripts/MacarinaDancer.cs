using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MacarinaDancer : MonoBehaviour
{
    public AudioSource MacarenaSong;
    // Start is called before the first frame update
    void Start()
    {
        MacarenaSong.Stop();
    }

  
    public void OnAnimationStarts()
    {
        MacarenaSong.Play();
    }
    public void OnAnimationEnds()
    {
        MacarenaSong.Stop();
    }
}
