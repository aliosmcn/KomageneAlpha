using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class DeliveryTable : MonoBehaviour
{
    [Header("Events")]
    [SerializeField] private ItemSOEvent onOrderDelivered;

    GameObject delivery;

    private void OnCollisionEnter(Collision collision)
    {
        //TESLÝME KONULAN OBJE BOÞ TABAK DEÐÝLSE YOK EDECEK
        if (collision.gameObject.GetComponent<Combiner>() && collision.gameObject.GetComponent<Item>().ItemData.ItemID != "T")
        {
            onOrderDelivered.Raise(collision.gameObject.GetComponent<Item>().ItemData);
            collision.gameObject.tag = "Untagged";
            delivery = collision.gameObject;
            Invoke(nameof(DestroyDelivery), 0.5f);
        }
    }

    private void DestroyDelivery()
    {
        Destroy(delivery);
    }
}
