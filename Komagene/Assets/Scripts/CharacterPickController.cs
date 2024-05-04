using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterPickController : Character
{

    [Header("Events")]
    [SerializeField] private VoidEvent onSpacePressed;


    [SerializeField] private GameObject containingObject = null;

    ClosestObjectManager closestObjectManager;

    [SerializeField] private GameObject toPickObject = null;
    Rigidbody rigid;

    [SerializeField] private Transform HoldPoint;

    Tezgah tezgah;

    protected override void OnEnable()
    {
        base.OnEnable();
        onSpacePressed.AddListener(SpacePressed);
    }

    protected override void OnDisable()
    {
        base.OnDisable();
        onSpacePressed.RemoveListener(SpacePressed);
    }

    protected override void Start()
    {
        base.Start();
        closestObjectManager = GetComponent<ClosestObjectManager>();
    }



    private void SpacePressed()
    {
        if(containingObject == null)
        {
            containingObject = toPickObject;
            if (toPickObject != null) rigid = containingObject.GetComponent<Rigidbody>();
            else return;
            containingObject.transform.position = HoldPoint.position;
            containingObject.transform.SetParent(HoldPoint);
            SetRbAndColliderActive(false);
            if (closestObjectManager.nearestObject != null)
            {
                tezgah = closestObjectManager.nearestObject.GetComponent<Tezgah>();
                tezgah.containedObject = null;
            }
        }
        else
        {
            // Elim dolu , Dolayýsýyla itemý býrak.
            if (closestObjectManager.nearestObject == null)
            {
                //Yere býrak
                SetRbAndColliderActive(true);
                containingObject.transform.parent = null;
                containingObject = null;
            }
            else
            {
                //masaya býrak
                tezgah = closestObjectManager.nearestObject.GetComponent<Tezgah>();
                SetRbAndColliderActive(true);
                containingObject.transform.parent = null;
                containingObject.transform.position = new Vector3(closestObjectManager.nearestObject.transform.position.x, closestObjectManager.nearestObject.transform.position.y + 0.83f, closestObjectManager.nearestObject.transform.position.z);
                tezgah.containedObject = containingObject;
                containingObject = null;
                
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("item"))
        {
            toPickObject = other.gameObject;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == toPickObject)
        {
            toPickObject = null;
        }
    }
    private void SetRbAndColliderActive(bool isActive)
    {
        rigid.useGravity = isActive;
        rigid.isKinematic = !isActive; 
        containingObject.GetComponent<BoxCollider>().isTrigger = !isActive;
    }

    
}
