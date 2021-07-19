using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// controls the Enemy's interaction
/// </summary>
public class EnemyController : MonoBehaviour
{
    private ParticleSystem effect;
    private ScoringPanelController scoringPanel;
    private void OnEnable()
    {
        if (effect == null)
            effect = FindObjectOfType<ParticleSystem>();
        if (scoringPanel == null)
            scoringPanel = FindObjectOfType<ScoringPanelController>();
        transform.LookAt(Camera.main.transform);
        Invoke("DisableObject", 10);
    }
    /// <summary>
    /// get invoked after a certain interval of time 
    /// to disabl ethe gameobject
    /// </summary>
    private void DisableObject()
    {
        gameObject.SetActive(false);
    }
    /// <summary>
    /// hides the enemy object and displays some effects
    /// </summary>
    /// <param name="collision"> collisions gameobject</param>
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Bullet"))
        {
            effect.transform.position = transform.position;
            effect.Play();
            scoringPanel.EnemyDown.Invoke();
            collision.gameObject.SetActive(false);
            gameObject.SetActive(false);
        }
    }
    private void Update()
    {
        var pos = Vector3.Lerp(transform.position, Camera.main.transform.position, Time.deltaTime/5);
        transform.position = new Vector3(pos.x,0.5f,pos.z);
    }
}
