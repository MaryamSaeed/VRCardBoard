using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BtnTest : MonoBehaviour
{
    public int count;
    public Text log;
    public bool logDefaultBtns = false, logInputManagerBtns = true;
    // Start is called before the first frame update
    void Start()
    {
        if(InputManager.Instance.getButton(InputManager.Instance.cross)){
            Debug.Log(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (log != null)
            log.text = "btn Log\n-------";

        if (logInputManagerBtns){
            Debug.Log("cross = " +InputManager.Instance.getButton(InputManager.Instance.cross));
            Debug.Log("circler = " +InputManager.Instance.getButton(InputManager.Instance.circler));
            Debug.Log("triangle = " +InputManager.Instance.getButton(InputManager.Instance.triangle));
            Debug.Log("square = " +InputManager.Instance.getButton(InputManager.Instance.square));
            Debug.Log("R1 = " +InputManager.Instance.getButton(InputManager.Instance.R1));
            Debug.Log("R2 = " +InputManager.Instance.getButton(InputManager.Instance.R2));
            Debug.Log("L1 = " +InputManager.Instance.getButton(InputManager.Instance.L1));
            Debug.Log("L2 = " +InputManager.Instance.getButton(InputManager.Instance.L2));
            Debug.Log("options = " +InputManager.Instance.getButton(InputManager.Instance.options));
            Debug.Log("share = " +InputManager.Instance.getButton(InputManager.Instance.share));
            Debug.Log("start = " +InputManager.Instance.getButton(InputManager.Instance.start));
            Debug.Log("RightStickClick = " +InputManager.Instance.getButton(InputManager.Instance.RightStickClick));
            Debug.Log("LeftStickClick = " +InputManager.Instance.getButton(InputManager.Instance.LeftStickClick));

            if(log != null){
               
                log.text +="\ncross = " +InputManager.Instance.getButton(InputManager.Instance.cross);
                log.text +="\ncircler = " +InputManager.Instance.getButton(InputManager.Instance.circler);
                log.text +="\ntriangle = " +InputManager.Instance.getButton(InputManager.Instance.triangle);
                log.text +="\nsquare = " +InputManager.Instance.getButton(InputManager.Instance.square);
                log.text +="\nR1 = " +InputManager.Instance.getButton(InputManager.Instance.R1);
                log.text +="\nR2 = " +InputManager.Instance.getButton(InputManager.Instance.R2);
                log.text +="\nL1 = " +InputManager.Instance.getButton(InputManager.Instance.L1);
                log.text +="\nL2 = " +InputManager.Instance.getButton(InputManager.Instance.L2);
                log.text +="\noptions = " +InputManager.Instance.getButton(InputManager.Instance.options);
                log.text +="\nshare = " +InputManager.Instance.getButton(InputManager.Instance.share);
                log.text +="\nstart = " +InputManager.Instance.getButton(InputManager.Instance.start);
                log.text +="\nRightStickClick = " +InputManager.Instance.getButton(InputManager.Instance.RightStickClick);
                log.text +="\nLeftStickClick = " +InputManager.Instance.getButton(InputManager.Instance.LeftStickClick);
            }
            
                                    
        }
        
        if(log != null)
            log.text += "\n---------------";

        if(logDefaultBtns)
            for(int i = 0; i <= count ; i++){
                //InputManager.Instance.GetBtn( InputManager.btn.)
                Debug.Log("btn"+i.ToString()+ " = "+ Input.GetButton("btn"+i.ToString()));
                if( log != null)        
                    log.text += "\nbtn"+i.ToString()+ " = "+ Input.GetButton("btn"+i.ToString());
            }
    }
    public void togleDefaultLog()
    {
        logDefaultBtns = !logDefaultBtns;
    }

    public void togleInputManagerLog()
    {
        logInputManagerBtns = !logInputManagerBtns;
    }

}
