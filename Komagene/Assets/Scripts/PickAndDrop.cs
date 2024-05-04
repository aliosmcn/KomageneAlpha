using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.Assertions.Must;
using UnityEngine.Rendering.UI;

public class PickAndDrop : MonoBehaviour
{
    Character character;
    
    public Transform pickUpPoint;      //karakterin �n�ndeki alan

    [SerializeField] private LayerMask interactMask;


    public bool playerHere;
    public bool readyToBreak;
    public bool itemIsPicked;
    public bool first;
    public bool canPick;

    bool isChildOfTable;

    private Rigidbody rb;
    private BoxCollider bC;



    void Start()
    {
        character = FindObjectOfType<Character>();
        rb = GetComponent<Rigidbody>();
        bC = GetComponent<BoxCollider>();
        pickUpPoint = GameObject.Find("Hold").transform;
        canPick = true;
    }
    
    private void Update()
    {
        if (this.transform.parent == null && !isChildOfTable)
        {
            rb.constraints = RigidbodyConstraints.None;
            rb.constraints = RigidbodyConstraints.FreezeRotation;
            isChildOfTable = true;
        }
        PickDrop();
        if (transform.parent != null)
        {
            if (this.transform.parent.CompareTag("DogramaTahtasi") && Input.GetKeyDown(KeyCode.LeftControl))
            {
                canPick = false;
            }
        }
            
    }

    private void StartRay()
    {

    }

    public void PickDrop()
    {
        //Silincek
        /*
        if (canPick)
        {
            if (playerHere)
            {
                // A�a��s� bir e�yay� alma k�sm�
                if (Input.GetKeyDown(KeyCode.Space))     //space bas�ld��� an, elde �r�n yok ve child obje yok ise
                {
                    if (itemIsPicked && first)
                    {
                        readyToBreak = true;       //b�rakmaya haz�r
                    }
                    if (!itemIsPicked && pickUpPoint.childCount < 1)
                    {
                        SetRigidbodyActive(false);      //eldeki objenin rigidbody bile�enleri kapan�r
                        bC.enabled = false;    //eldeki objenin collider� kapan�r

                        this.transform.position = pickUpPoint.position;     //obje pickUpPointe ���nlan�r
                        this.transform.parent = GameObject.Find("Hold").transform;      //obje Hold objesinin child� olur

                        itemIsPicked = true;    //elde obje bulunuyor
                        readyToBreak = false;
                    }


                }


                if (Input.GetKeyUp(KeyCode.Space))
                {
                    if (itemIsPicked)
                    {
                        first = true;
                        if (readyToBreak)
                        {
                            this.transform.parent = null;       //objeyi child olmaktan ��kar
                            bC.enabled = true;        //collider aktif et
                            this.bC.isTrigger = false;
                            SetRigidbodyActive(true);           //rb aktif et

                            itemIsPicked = false;       //elde obje yok
                            first = false;        //objeyi b�rakmaya haz�r de�il
                        }
                        readyToBreak = false;       //haz�r de�il 2
                    }
                }
            }
        }*/
    }

    //Silinecek
    /*
    public void SetRigidbodyActive(bool isActive)
    {
        rb.useGravity = isActive;
        rb.isKinematic = !isActive; // Rigidbody'nin kinematik �zelli�ini ayarla
        rb.detectCollisions = isActive; // �arp��malar�n alg�lanmas�n� ayarla (E�er devre d��� ise �arp��malar alg�lanmaz)
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerHere = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        playerHere = false;
    }*/

    private void OnCollisionEnter(Collision collision)
    {
        
        if (collision.gameObject.CompareTag("Masa") || collision.gameObject.CompareTag("DogramaTahtasi"))
        {
            Vector3 normal = collision.contacts[0].normal;

            if (normal == Vector3.up)
            {
                if (collision.gameObject.transform.childCount == 0)
                {
                    this.transform.position = new Vector3(collision.transform.position.x, collision.transform.position.y + 0.83f, collision.transform.position.z);
                    this.transform.parent = collision.transform;
                    rb.constraints = RigidbodyConstraints.FreezeAll;
                    isChildOfTable = false;
                    bC.enabled = true;
                }
            }
        }
    }
}
