using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class t : MonoBehaviour
{

    public Text Btnlog,log;
    string []buttons = {
        "square",
        "cross",
        "circle",
        "triangle",
        "L1",
        "R1",
        "L2",
        "R2",
        "share",
        "options",
        "leftStickClick",
        "rightSticjClick",
        "playsttion",
        "touchPadClick"
    };

    string []axises = { 
        "leftStickX" , 
        "leftStickY" , 
        "rightStickX" , 
        "rightStickY" , 
        "L2" , 
        "R2" , 
        "arrowsX" , 
        "arrowsY" 
    };


    // Update is called once per frame
    void Update()
    {
        for (int i =0 ; i<buttons.Length ; i++){
            if(Input.GetButton(buttons[i])){
                Debug.Log(buttons[i] + " clicked !");
                Btnlog.text =  buttons[i] + " clicked !" ;
            }
        }
        log.text = "";
        for (int i =0 ; i<axises.Length ; i++){
            if(Input.GetAxis(axises[i]) != 0){
                Debug.Log(axises[i] + " = " + Input.GetAxis(axises[i]) );
                log.text += "\n" + (axises[i] + " = " + Input.GetAxis(axises[i]) );
            }
        }

       // Debug.Log("X = " + Input.GetAxis("axisX") + " Y = " +Input.GetAxis("axisY"));
    }


}
