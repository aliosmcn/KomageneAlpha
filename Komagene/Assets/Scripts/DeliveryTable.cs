using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class DeliveryTable : MonoBehaviour
{
    [Header("Events")]
    [SerializeField] private ItemSOEvent onOrderDelivered;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "item")
        {
            onOrderDelivered.Raise(collision.gameObject.GetComponent<Item>().ItemData);
        }
    }
}
