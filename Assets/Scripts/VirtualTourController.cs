using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class VirtualTourController : MonoBehaviour
{
    public HotspotEvent NavigateToPoint;
    public HotspotEvent HotSpotChanged;
    public List<Texture2D> TourImages;
    private Material Material360;
    private void Awake()
    {
        NavigateToPoint = new HotspotEvent();
        HotSpotChanged = new HotspotEvent();
    }
    // Start is called before the first frame update
    void Start()
    {
        NavigateToPoint.AddListener(OnNavigateToPoint);
        Material360 = GetComponent<MeshRenderer>().materials[0];
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnNavigateToPoint(int hotspotid)
    {
        Material360.mainTexture = TourImages[hotspotid] as Texture;
        HotSpotChanged.Invoke(hotspotid);
    }
}
public class HotspotEvent : UnityEvent<int>
{ }
