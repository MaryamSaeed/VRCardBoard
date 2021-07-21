using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class Shooter : MonoBehaviour
{
    public GameObject NormalBulletPrefab;
    public GameObject SeekerBulletPrefab;
    public GvrReticlePointer rectilPointer;
    [HideInInspector]
    public UnityEvent SeekerModeActivated;
    [HideInInspector]
    public UnityEvent NormalModeActivated;
    public int NormalBulletPoollength;
    private List<GameObject> normalBulletPool;
    private List<GameObject> seekerBulletPool;
    private int currentBullet = 0;
    private int seekerBulletsCount = 4;
    private bool seekerMode;
    // Start is called before the first frame update
    private void Start()
    {
        InitBulltePools();
        InitEvents();
    }
    private void InitEvents()
    {
        SeekerModeActivated = new UnityEvent();
        SeekerModeActivated.AddListener(OnSeekerModeActivated);
        NormalModeActivated = new UnityEvent();
        NormalModeActivated.AddListener(OnNormalModeActivated);
    }
    private void InitBulltePools()
    {
        normalBulletPool = new List<GameObject>();
        seekerBulletPool = new List<GameObject>();
        if (NormalBulletPoollength > 0)
        {
            for (int i = 0; i < NormalBulletPoollength; i++)
                normalBulletPool.Add(Instantiate(NormalBulletPrefab));
        }
        for (int j = 0; j < seekerBulletsCount; j++)
            seekerBulletPool.Add(Instantiate(SeekerBulletPrefab));
    }
    // Update is called once per frame
    private void Update()
    {
        if (Input.touchCount == 1 && Input.touches[0].phase == TouchPhase.Ended)
            Shoot();
        else if (Input.GetMouseButtonUp(0))
            Shoot();
    }
    /// <summary>
    /// shoot a normal bullet in the forward direction of 
    /// the camera
    /// </summary>
    private void ShootNormalBullet()
    {
        normalBulletPool[currentBullet].transform.position = transform.position;
        normalBulletPool[currentBullet].SetActive(true);
        normalBulletPool[currentBullet].GetComponent<Rigidbody>().AddForce(10 * Camera.main.transform.forward, ForceMode.Impulse);
        currentBullet = (currentBullet + 1) % NormalBulletPoollength;
    }
    private void ShootSeekerBullet()
    {
        seekerBulletPool[currentBullet].transform.position = transform.position;
        seekerBulletPool[currentBullet].SetActive(true);
        if (currentBullet < seekerBulletsCount - 1)
            currentBullet++;
        else
        {
            FindObjectOfType<ScoringPanelController>().StartCoolDown.Invoke();
            seekerMode = false;
        }
    }
    private void OnSeekerModeActivated()
    {
        SetSeekerModeFlag(true);
        currentBullet = 0;
    }
    private void Shoot()
    {
        if (IsNotUIElement())
        {
            if (seekerMode)
                ShootSeekerBullet();
            else
                ShootNormalBullet();
        }
    }
    private bool IsNotUIElement()
    {
        if (rectilPointer.CurrentRaycastResult.gameObject != null)
        {
            if (rectilPointer.CurrentRaycastResult.gameObject.layer == LayerMask.NameToLayer("UI"))
                return false;
            else
                return true;
        }
        else return true;
    }
    private void OnNormalModeActivated()
    {
        SetSeekerModeFlag(false);
    }
    private void SetSeekerModeFlag(bool seeking)
    {
        seekerMode = seeking;
        currentBullet = 0;
    }
}
