using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Profiling;
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
        Sprite recipeIcon = order.OrderRecipe.result.ItemIcon;
        orderUIPrefab.GetComponent<Image>().sprite = recipeIcon;
        
        Instantiate(orderUIPrefab, this.transform);
    }


    private void RemoveOrderFromUI(OrderSO orderToClose)
    {
        
    }
}
