using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OrderUIController : MonoBehaviour
{

    [SerializeField] private OrderSOEvent onOrderCreated;
    [SerializeField] private OrderSOEvent onOrderClosed;
    
    [SerializeField] private GameObject orderUIPrefab;

    [SerializeField] private List<GameObject> orderUIs;
    
    private void OnEnable()
    {
        onOrderCreated.AddListener(CreateOrderUI);
        onOrderClosed.AddListener(RemoveOrderFromUI);
    }

    private void OnDisable()
    {
        onOrderCreated.RemoveListener(CreateOrderUI);
        onOrderClosed.RemoveListener(RemoveOrderFromUI);
    }

    private void CreateOrderUI(OrderSO order)
    {
        
    }

    private void RemoveOrderFromUI(OrderSO orderToClose)
    {
        
    }
}
