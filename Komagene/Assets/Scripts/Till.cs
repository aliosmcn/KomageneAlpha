using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;
using static Unity.Burst.Intrinsics.Arm;

public class Till : MonoBehaviour
{
    
    [Header("Prefabs")]
    [SerializeField] private GameObject domates;
    [SerializeField] private GameObject tabak;
    [SerializeField] private GameObject marul;
    [SerializeField] private GameObject cigKofte;
    [SerializeField] private GameObject limon;
    [SerializeField] private GameObject narEksisi;

    Rigidbody objRb;
    BoxCollider objCll;

    Animator animator;
    private bool playerInside = false;

    void Start()
    {
        if (GetComponent<Animator>())
        {
            animator = GetComponent<Animator>();
        }
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
            case "LimonSpawn":
                Spawn(limon);
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
                case "LimonSpawn":
                    Spawn(limon);
                    break;
                default:
                    break;
            }
        }
        if (playerInside && Input.GetKeyDown(KeyCode.Space) && GetComponent<Animator>())
        {
            animator.SetBool("isTake", true);
            Invoke(nameof(SetAnimationFalse), 0.625f);
        }
    }
    
    void Spawn(GameObject nesne)
    {
        if (GameObject.Find("Hold").transform.childCount == 0)
        {
            GameObject newObject;
            newObject = Instantiate(nesne);
            newObject.transform.position = new Vector3(this.transform.position.x, transform.position.y - 0.1f, transform.position.z);
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
            newObject.transform.position = new Vector3(this.transform.position.x, transform.position.y + 0.5f, this.transform.position.z);
            newObject.transform.localScale = tabak.transform.localScale;
            newObject.transform.SetParent(transform);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            playerInside = true;
        }
        

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInside = false; // Karakter kutudan çýktý
        }
    }

    private void SetAnimationFalse()
    {
        animator.SetBool("isTake", false);
    }
}
