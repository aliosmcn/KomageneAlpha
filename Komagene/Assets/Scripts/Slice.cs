using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Slice : MonoBehaviour
{

    [SerializeField] private VoidEvent onSliceToggle;

    bool playerHere;

    string sliceObjectTag;

    public GameObject[] foods;
    public GameObject[] slicedObjects;



    void Update()
    {
        SliceObject();
    }

    void SliceObject()
    {
        if (playerHere && Input.GetKeyDown(KeyCode.LeftControl))
        {
            if (this.transform.childCount > 0)
            {
                
                Debug.Log("Kes");
                onSliceToggle.Raise();
                Invoke("Destroy", 4f);
            }
        }
    }

    

    void Destroy()
    {
        Debug.Log("Kesildi");
        Destroy(transform.GetChild(0).gameObject);
        sliceObjectTag = transform.GetChild(0).tag;
        onSliceToggle.Raise();
        Create();
    }

    void Create()
    {
        switch (sliceObjectTag)
        {
            case "Domates":
                //kesilmiþ domates oluþtur
                break;
            default:
                break;
        }
    }

    void Transition(GameObject obj)
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerHere = true;
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        playerHere = false;
    }

}
