using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;

public class OrderSystem : MonoTimer
{

    [SerializeField] private OrderSOEvent onOrderTimeOut;
    [SerializeField] private OrderSOEvent onOrderCreated;
    [SerializeField] private ItemSOEvent onOrderDelivered; //bu teslim tezgahında raise edilecek
    [SerializeField] private OrderSOEvent onOrderClosed;
    
    int randomOrderIndex;

    // Gelebilecek bütün orderlar
    [SerializeField] private List<OrderSO> Orders;

    [SerializeField] private float orderTime = 3f;

    [SerializeField] private int maxOrderCount = 3;
    // Gelmiş orderlar
    [SerializeField] private List<OrderSO> currentOrders = new List<OrderSO>();
    
    private void OnEnable()
    {
        onOrderTimeOut.AddListener(CloseOrder);
        onOrderDelivered.AddListener(CheckOrderCorrect);
    }

    private void OnDisable()
    {
        onOrderTimeOut.RemoveListener(CloseOrder);
        onOrderDelivered.RemoveListener(CheckOrderCorrect);
    }

    private void Start()
    {

        base.setRemainingTime(orderTime);
        base.StartTimer();
    }

    protected override void TimeIsUp()
    {
        CreateNewOrder();
        ResetTimer();
    }

    private void CreateNewOrder()
    {
        if (currentOrders.Count >= maxOrderCount) return;
        randomOrderIndex = Random.Range(0, Orders.Count);
        OrderSO newOrder = Orders[randomOrderIndex];
        currentOrders.Add(newOrder);
        onOrderCreated.Raise(newOrder);
    }

    public void CloseOrder(OrderSO toCloseOrder)
    {
        
        currentOrders.Remove(toCloseOrder);
    }

    private void CloseOrder(OrderSO toCloseOrder, bool waiterClose)
    {
        currentOrders.Remove(toCloseOrder);
        onOrderClosed.Raise(toCloseOrder);
    }

    private void CheckOrderCorrect(ItemSO deliveredMeal)
    {
        foreach (OrderSO order in currentOrders)
        {
            if (order.OrderRecipe.result == deliveredMeal)
            {
                CloseOrder(order, true);
                return;
            }
        }
        FalseOrder();
    }
    
    private void FalseOrder()
    {

    }
    
    
}
