using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

[RequireComponent(typeof(ARPlaneManager))]
public class ARPlaceObjectBySize : MonoBehaviour
{
    [SerializeField] private MeshRenderer _objectSize;
    [SerializeField] private GameObject _objectPrefab;

    private ARPlaneManager _planeManger;
    private List<ARPlane> _listPlanes;
    private GameObject _objectPlaced;

    private void Awake()
    {
        _planeManger = GetComponent<ARPlaneManager>();
        _listPlanes = new List<ARPlane>();
    }

    private void OnEnable() {
        _planeManger.planesChanged += PlanesFound;
    }

    private void OnDisable() {
        _planeManger.planesChanged -= PlanesFound;
    }

    private void PlanesFound(ARPlanesChangedEventArgs eventData)
    {
        if(eventData.added != null && eventData.added.Count > 0)
        {
            _listPlanes.AddRange(eventData.added);
        }

        foreach (var plane in _listPlanes)
        {
            if(CompareSizeWithObject(plane) && _objectPlaced == null)
            {

            }
        }
    }

    private bool CompareSizeWithObject(ARPlane plane)
    {
        return plane.extents.x > _objectSize.bounds.size.x && plane.extents.y > _objectSize.bounds.size.z;
    }

}   

