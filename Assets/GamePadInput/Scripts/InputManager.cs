using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public string mobileModel = "Samsung S9+";
    public enum btn {
        btn0,btn1,btn2,btn3,btn4,btn5,btn6,btn7,btn8,btn9,btn10,btn11,btn12,btn13,btn14,btn15
    };

    public enum ax{
        ax1, ax2,ax3,ax4,ax5,ax6,ax7,ax8,ax9,ax10,ax11,ax12,ax13,ax14,ax15,ax16,ax17,ax18,ax19,ax20
    };
    [Header("Buttons (value) = (True, False)")]

    public btn cross = btn.btn0; 
    public btn circler= btn.btn1,
    triangle= btn.btn3,
    square=btn.btn2,
    R1= btn.btn5,
    R2=btn.btn7,
    L1=btn.btn4,
    L2=btn.btn6,
    options=btn.btn10,
    share=btn.btn11,
    start=btn.btn12,
    RightStickClick=btn.btn9,
    LeftStickClick =btn.btn8;
    
    [Header("Axis (value) = [-1 : 1]")]
    public ax X = ax.ax5;
    public ax Y = ax.ax6, 
    RightStick_X = ax.ax3,
    RightStick_Y = ax.ax4 ,
    LeftStick_X = ax.ax1 , 
    LeftStick_Y = ax.ax2,
    _R2 = ax.ax8,
    _L2 = ax.ax7;

    public static InputManager Instance;
    void Awake()
    {
        if(Instance == null)
            Instance = this;
        else
            Destroy(this);
    }
    


    public bool getButton(btn mBtn){        
        return Input.GetButton(mBtn.ToString());
    }
    public bool getButtonDown(btn mBtn){
        //Debug.Log(mBtn.ToString());
        return Input.GetButtonDown(mBtn.ToString());
    }
    public bool getButtonUp(btn mBtn){
        //Debug.Log(mBtn.ToString());
        return Input.GetButtonUp(mBtn.ToString());
    }

    public float getAxis(ax ax){
        return Input.GetAxis(ax.ToString());
    }
}
