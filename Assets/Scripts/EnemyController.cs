using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// controls the Enemy's interaction
/// </summary>
public class EnemyController : MonoBehaviour
{
    private ParticleSystem Effect;
    private ScoringPanelController scoringPanel;
    private void OnEnable()
    {
        Effect = FindObjectOfType<ParticleSystem>();
        scoringPanel = FindObjectOfType<ScoringPanelController>();
        Invoke("DisableObject", 15);
    }

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
            Effect.transform.position = transform.position;
            Effect.Play();
            scoringPanel.EnemyDown.Invoke();
            collision.gameObject.SetActive(false);
            gameObject.SetActive(false);
        }
    }
}
