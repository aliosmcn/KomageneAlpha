using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Unity.VisualScripting;
using UnityEngine;

public class OrderUI : MonoTimer
{
    [SerializeField] private OrderSOEvent onOrderCreated;
    [SerializeField] private OrderSOEvent onOrderClosed;
    [SerializeField] private OrderSOEvent onOrderTimeOut;
    
    
    [SerializeField] private float orderTime = 30f; 
    [SerializeField] private OrderSO currentOrder;


    private void OnEnable()
    {
        onOrderCreated.AddListener(SetOrderSO);
        onOrderClosed.AddListener(RemoveOrderSO);
    }

    private void OnDisable()
    {
        onOrderCreated.RemoveListener(SetOrderSO);
        onOrderClosed.RemoveListener(RemoveOrderSO);
    }

    void Start()
    {
        base.setRemainingTime(orderTime);
        base.StartTimer();
    }

    protected override void TimeIsUp()
    {
        onOrderTimeOut.Raise(currentOrder);
    }

    private void SetOrderSO(OrderSO order)
    {
        if (currentOrder != null) return;
        else currentOrder = order;
    }

    private void RemoveOrderSO(OrderSO order)
    {
        if (currentOrder == null) return;
        else currentOrder = null;
    }
}
