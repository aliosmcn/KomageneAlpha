using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrderUI : MonoTimer
{

    [SerializeField] private OrderSOEvent onOrderTimeOut;
    
    
    [SerializeField] private float orderTime = 25f; 
    [SerializeField] private OrderSO currentOrder;
    
    void Start()
    {
        base.setRemainingTime(orderTime);
        base.StartTimer();
    }

    protected override void TimeIsUp()
    {
        onOrderTimeOut.Raise(currentOrder);
    }
}
