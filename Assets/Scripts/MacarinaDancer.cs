using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MacarinaDancer : MonoBehaviour
{
    public UnityEngine.Events.UnityEvent AnimationEnded;
    public AudioSource MacarenaSong;
    private Animator DancerAnimator;
    // Start is called before the first frame update
    void Start()
    {
        MacarenaSong.Stop();
        DancerAnimator = GetComponent<Animator>();
        DancerAnimator.enabled = false;
    }
    public void OnAnimationStarts()
    {
        MacarenaSong.Play();
    }
    public void OnAnimationEnds()
    {
        AnimationEnded.Invoke();
        MacarenaSong.Stop();
        DancerAnimator.enabled = false;
    }
    public void OnStartMacarinaDance()
    {
        DancerAnimator.enabled = true;
        DancerAnimator.Play("MacarenaDance");
    }
}
