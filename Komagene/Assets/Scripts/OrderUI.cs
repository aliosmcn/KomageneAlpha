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
    
    
    [SerializeField] private float orderTime = 3f; 
    [SerializeField] public OrderSO currentOrder;

    LTRect uiItself;

    void Start()
    {
        
        base.setRemainingTime(orderTime);
        base.StartTimer();
        
        
    }

    private void updateHeight(float newVal)
    {
        
    }

    protected override void TimeIsUp()
    {
        onOrderTimeOut.Raise(currentOrder);
        onOrderClosed.Raise(currentOrder);
    }

}
