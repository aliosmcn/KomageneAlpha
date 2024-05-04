using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tezgah : MonoBehaviour
{
    // Masada duran obje
    [SerializeField]private GameObject containedObject = null;

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
    
    public void setContainedObject(GameObject toContainObject)
    {
        this.containedObject = toContainObject;
        Item item = toContainObject.GetComponent<Item>();
        
    }

    
}
