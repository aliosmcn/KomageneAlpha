using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;
using static Unity.Burst.Intrinsics.Arm;

public class Till : MonoBehaviour
{
    public bool readyToSpawn;

    [Header("Prefabs")]
    public GameObject domates;
    public GameObject tabak;
    public GameObject marul;
    public GameObject cigKofte;

    Rigidbody objRb;
    BoxCollider objCll;

    void Start()
    {
        readyToSpawn = true;

        switch (this.tag)
        { 
            case "DomatesSpawn":
                Spawn(domates);
                break;
            case "TabakSpawn":
                SpawnTabak();
                break;
            case "MarulSpawn":
                Spawn(marul);
                break;
            case "CigKofteSpawn":
                Spawn(cigKofte);
                break;
            default:
                break;
        }
    }

    private void Update()
    {
        if (this.transform.childCount < 2)
        {
            switch (this.tag)
            {
                case "DomatesSpawn":
                    Spawn(domates);
                    break;
                case "TabakSpawn":
                    SpawnTabak();
                    break;
                case "MarulSpawn":
                    Spawn(marul);
                    break;
                case "CigKofteSpawn":
                    Spawn(cigKofte);
                    break;
                default:
                    break;
            }
        }
    }
    
    void Spawn(GameObject nesne)
    {
        if (GameObject.Find("Hold").transform.childCount == 0)
        {
            GameObject newObject;
            newObject = Instantiate(nesne);
            newObject.transform.position = new Vector3(this.transform.position.x, transform.position.y + 0.15f);
            newObject.transform.localScale = nesne.transform.localScale;
            newObject.transform.SetParent(transform);
            objCll = GetComponentInParent<BoxCollider>();
            objRb = GetComponentInParent<Rigidbody>();
        }
    }

    void SpawnTabak()
    {
        if (GameObject.Find("Hold").transform.childCount == 0)
        {
            GameObject newObject;
            newObject = Instantiate(tabak);
            newObject.transform.position = new Vector3(this.transform.position.x, transform.position.y + 1f, this.transform.position.z);
            newObject.transform.localScale = tabak.transform.localScale;
            newObject.transform.SetParent(transform);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == null)
        {
            readyToSpawn = false;
        }
        if (collision.gameObject.CompareTag("Player") && Input.GetKeyDown(KeyCode.Space))
        {
            objCll.isTrigger = false;
            objRb.useGravity = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        readyToSpawn = true;
    }
}
