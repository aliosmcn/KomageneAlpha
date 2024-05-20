using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClosestObjectManager : MonoBehaviour
{
    [SerializeField] private IntEvent onNearestObjectFound;

    [SerializeField] private Material focusHighlight;
    [SerializeField] private float radius = 1.3f;

    [SerializeField] private Material unFocusedMaterial;

    public GameObject nearestObject = null;

    [SerializeField] LayerMask mask;

    private static ClosestObjectManager instance;
    

    public static ClosestObjectManager Instance
    {
        get
        {
            return instance;
        }
    }

    private void Awake()
    {
        instance = this;
    }

    void Update()
    {
        NearObjects(transform.position, radius);
    }

    void NearObjects(Vector3 center, float radius)
    {
        Collider[] hitColliders = Physics.OverlapSphere(center, radius, mask);
        Collider nearestCollider = null;
        float nearestDistance = Mathf.Infinity;

        foreach (var hitCollider in hitColliders)
        {
            float distance = Vector3.Distance(center, hitCollider.transform.position);
            if (distance < nearestDistance)
            {
                nearestDistance = distance;
                nearestCollider = hitCollider;            
            }          
        }

        if (nearestCollider != null)
        {
            nearestObject = nearestCollider.gameObject;
            //focusHighlight.SetFloat("_deger", 2);
            if (nearestObject.tag != "Teslim")
            {
                nearestObject.GetComponent<MeshRenderer>().sharedMaterial = focusHighlight;
                onNearestObjectFound.Raise(nearestObject.GetHashCode());

            }
        }
   
    }
}
