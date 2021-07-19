using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.Events;
/// <summary>
/// controls the Score panel and the events related to it
/// </summary>
public class ScoringPanelController : MonoBehaviour
{
    //public
    [Tooltip("the score number's textbox")]
    public TextMeshProUGUI ScoreNumber;
    [Tooltip("the cooldown bar fillable Image")]
    public Image CoolDownBar;
    [HideInInspector]
    public UnityEvent EnemyDown;
    //private
    private int score;
    private int coolDownTime;
    // Start is called before the first frame update
    void Start()
    {
        EnemyDown = new UnityEvent();
        EnemyDown.AddListener(OnEnemyDown);
        score = 0;
        CoolDownBar.fillAmount = 0;
    }
    /// <summary>
    /// when enemy is down increase the score 
    /// </summary>
    private void OnEnemyDown()
    {
        score++;
        ScoreNumber.text = score.ToString();
    }
    /// <summary>
    /// activates the seeker shooting mode and notify enemies
    /// with the change
    /// </summary>
    public void OnSeekerModeSelected()
    {
        Debug.Log("Seeker Mode selected");
    }
    /// <summary>
    /// switchs to the normal shooting mode around the user
    /// </summary>
    public void OnNormalModeSelected()
    {
        Debug.Log("Normal Mode selected");
    }
}
