using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class Video360Controller : MonoBehaviour
{
    private VideoPlayer video360Player;
    // Start is called before the first frame update
    void Start()
    {
        video360Player = GetComponent<VideoPlayer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnPlay360Video()
    {
        Camera.main.transform.parent.position = transform.position;
        OnPlay();
    }

    public void OnPlay()
    {
        video360Player.Play();
    }
    public void OnPause360Video()
    {
        video360Player.Pause();
    }
    public void OnStop360Video()
    {
        FindObjectOfType<VirtualTourController>().NavigateToPoint.Invoke(0);
        Camera.main.transform.parent.position = Vector3.zero;
        Camera.main.transform.forward = Vector3.forward;
    }
}
