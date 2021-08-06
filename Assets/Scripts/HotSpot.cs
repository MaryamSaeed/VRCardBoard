using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class HotSpot : MonoBehaviour,IPointerClickHandler
{
    public int HotspotID;
    private VirtualTourController tourController;
    private SphereCollider hotspotCollider;
    // Start is called before the first frame update
    void Start()
    {
        tourController = FindObjectOfType<VirtualTourController>();
        tourController.HotSpotChanged.AddListener(OnHotSpotChanged);
        hotspotCollider = GetComponent<SphereCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        Camera.main.transform.parent.position = transform.position;
        tourController.NavigateToPoint.Invoke(HotspotID);
        hotspotCollider.enabled = false;
    }
    private void OnHotSpotChanged(int currentid)
    {
        if (currentid == HotspotID)
            hotspotCollider.enabled = false;
        else
            hotspotCollider.enabled = true;
    }
}
