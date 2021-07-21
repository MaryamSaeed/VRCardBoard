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
    [HideInInspector]
    public UnityEvent StartCoolDown;
    private UnityEvent coolDownEnded;
    //private
    private int score;
    private int coolDownTime = 10;
    private bool seekButtonActive = true;
    // Start is called before the first frame update
    void Start()
    {
        EnemyDown = new UnityEvent();
        EnemyDown.AddListener(OnEnemyDown);
        StartCoolDown = new UnityEvent();
        StartCoolDown.AddListener(OnStartCoolDown);
        coolDownEnded = new UnityEvent();
        coolDownEnded.AddListener(OnCoolDownEnded);
        score = 0;
        CoolDownBar.fillAmount = 0;
    }
    /// <summary>
    /// when enemy is down increase the score 
    /// </summary>
    private void OnEnemyDown()
    {
        if (seekButtonActive)
            score++;
        else
            score += 2;
        ScoreNumber.text = score.ToString();
    }

    private void OnStartCoolDown()
    {
        seekButtonActive = false;
        StartCoroutine("UpdateCoolDownProgressBar");
    }
    /// <summary>
    /// animates the cooldown bar progress
    /// </summary>
    /// <returns></returns>
    private IEnumerator UpdateCoolDownProgressBar()
    {
        var cooltime = 0.0f;
        while (cooltime <= coolDownTime)
        {
            CoolDownBar.fillAmount = cooltime / coolDownTime;
            cooltime += Time.deltaTime;
            yield return null;
        }
        coolDownEnded.Invoke();
    }
    /// <summary>
    /// activates seeker button and resets the cooldown bar
    /// </summary>
    private void OnCoolDownEnded()
    {
        CoolDownBar.fillAmount = 0;
        seekButtonActive = true;
    }
    /// <summary>
    /// activates the seeker shooting mode and notify enemies
    /// with the change
    /// </summary>
    public void OnSeekerModeSelected()
    {
        if (seekButtonActive)
        {
            FindObjectOfType<Shooter>().SeekerModeActivated.Invoke();
            seekButtonActive = false;
        }
    }
    /// <summary>
    /// switchs to the normal shooting mode around the user
    /// </summary>
    public void OnNormalModeSelected()
    {
        if (!seekButtonActive)
        {
            FindObjectOfType<Shooter>().NormalModeActivated.Invoke();
            StopAllCoroutines();
            OnCoolDownEnded();
        }
    }
    private void OnDisable()
    {
        StopAllCoroutines();
    }
}
