using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AxisTest : MonoBehaviour
{
    
    public int count;
    public Text log;
    public bool logDefaultAxis = false, logInputManagerAxis = true;

    // Update is called once per frame
    void Update()
    {
        if(log != null)
            log.text = "ax log\n-------";

        if(logInputManagerAxis){
            Debug.Log("X = " + InputManager.Instance.getAxis(InputManager.Instance.X));
            Debug.Log("\nY = " + InputManager.Instance.getAxis(InputManager.Instance.Y));
            Debug.Log("\nRightStick_X = " + InputManager.Instance.getAxis(InputManager.Instance.RightStick_X));
            Debug.Log("\nRightStick_Y = " + InputManager.Instance.getAxis(InputManager.Instance.RightStick_Y));
            Debug.Log("\nLeftStick_X  = " + InputManager.Instance.getAxis(InputManager.Instance.LeftStick_X ));
            Debug.Log("\nLeftStick_Y  = " + InputManager.Instance.getAxis(InputManager.Instance.LeftStick_Y ));
            Debug.Log("\nR2 = " + InputManager.Instance.getAxis(InputManager.Instance._R2));
            Debug.Log("\nL2 = " + InputManager.Instance.getAxis(InputManager.Instance._L2));
            
            
            
            if(log != null){
                log.text += "\nX = " + InputManager.Instance.getAxis(InputManager.Instance.X);
                log.text += "\nY = " + InputManager.Instance.getAxis(InputManager.Instance.Y);
                log.text += "\nRightStick_X = " + InputManager.Instance.getAxis(InputManager.Instance.RightStick_X);
                log.text += "\nRightStick_Y = " + InputManager.Instance.getAxis(InputManager.Instance.RightStick_Y);
                log.text += "\nLeftStick_X  = " + InputManager.Instance.getAxis(InputManager.Instance.LeftStick_X );
                log.text += "\nLeftStick_Y  = " + InputManager.Instance.getAxis(InputManager.Instance.LeftStick_Y );
                log.text += "\nR2 = " + InputManager.Instance.getAxis(InputManager.Instance._R2);
                log.text += "\nL2 = " + InputManager.Instance.getAxis(InputManager.Instance._L2);
            }

        }
        
        if(log != null)
            log.text += "\n---------------";

        if(logDefaultAxis)
            for(int i = 1; i <= count ; i++){
                Debug.Log("ax"+i.ToString()+ " = "+ Input.GetAxis("ax"+i.ToString()));

                if(log != null){
                    log.text += "\nax"+i.ToString()+ " = "+ Input.GetAxis("ax"+i.ToString());
                }
            }
    }
    
    public void togleDefaultLog()
    {
        logDefaultAxis = !logDefaultAxis;
    }

    public void togleInputManagerLog()
    {
        logInputManagerAxis = !logInputManagerAxis;
    }

}
