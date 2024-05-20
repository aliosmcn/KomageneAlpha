using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class Tezgah : MonoBehaviour
{
    [SerializeField] private IntEvent onNearestObjectFound;
    // Masada duran obje
    [SerializeField] private GameObject containedObject = null;
    [SerializeField] private Material focusedMaterial, unFocusedMaterial;

    private void OnEnable()
    {
        onNearestObjectFound.AddListener(SetUnfocusMat);
    }
    private void OnDisable()
    {
        onNearestObjectFound.RemoveListener(SetUnfocusMat);
    }

    public GameObject ContainedObject
    {
        get
        {
            return this.containedObject;
        }
        set
        {
            containedObject = value;
        }
    }
    
    public void SetContainedObject(GameObject toContainObject)
    {
        this.containedObject = toContainObject;
        Item item = toContainObject.GetComponent<Item>();
        if (GetComponent<DeliveryTable>())
        {
            GetComponent<DeliveryTable>().Delivery(toContainObject);
        }
    }

    public void SetUnfocusMat(int unFocusedHashCode)
    {
        Debug.Log(gameObject.name);
        Debug.Log("UNFOCUSED: " + unFocusedHashCode);
        Debug.Log(gameObject.GetHashCode());
        if (gameObject.tag == "Teslim") return;
        if (gameObject.GetHashCode() == unFocusedHashCode)
        {
            gameObject.GetComponent<MeshRenderer>().sharedMaterial = focusedMaterial;
        }
        else
        {
            gameObject.GetComponent<MeshRenderer>().sharedMaterial = unFocusedMaterial;
        }
    }


}
