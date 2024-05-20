using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEditor;

public class GameManager : MonoBehaviour
{
    [Header("Events")]
    [SerializeField] private IntEvent onMoneyValueChanged;
    [SerializeField] private ItemSOEvent onItemPicked;
    [SerializeField] private VoidEvent onTimeFinished;
    [SerializeField] private ItemSOEvent onOrderDelivered;

    [Header("UI")]
    [SerializeField] private GameObject finishPanel;
    [SerializeField] private Text hasilatText;
    [SerializeField] private Text ordersText;


    List<GameObject> foods = new List<GameObject>();
    List<string> deliveredOrders = new List<string>();

    public int money;

    

    private void OnEnable()
    {
        onMoneyValueChanged.AddListener(MoneyValueChange);
        onItemPicked.AddListener(AddItemList);
        onTimeFinished.AddListener(TimeFinished);
        onOrderDelivered.AddListener(AddOrderList);
    }
    private void OnDisable()
    {
        onMoneyValueChanged.RemoveListener(MoneyValueChange);
        onItemPicked.RemoveListener(AddItemList);
        onTimeFinished.RemoveListener(TimeFinished);
        onOrderDelivered.RemoveListener(AddOrderList);
    }

    private void MoneyValueChange(int deger)
    {
        money += deger;
    }

    private void AddItemList(ItemSO item)
    {
        foods.Add(item.prefab);
    }

    private void AddOrderList(ItemSO order)
    {
        deliveredOrders.Add(order.itemName);
        Debug.Log(deliveredOrders[0]);
    }


    private void TimeFinished()
    {
        Debug.Log("zaman bitti");
        finishPanel.SetActive(true);
        hasilatText.text = money.ToString();
        for (int i = 0; i < deliveredOrders.Count; i++)
        {
            ordersText.text += " - " + deliveredOrders[i] + "\n";
        }
    }

    
    private void Update()
    {
        if (finishPanel.activeSelf)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                finishPanel.SetActive(false);
                SceneManager.LoadScene(0);
            }
            if (Input.GetKeyDown(KeyCode.Space))
            {
                //SceneManager.LoadScene(2);
            }
        }
    }
}
