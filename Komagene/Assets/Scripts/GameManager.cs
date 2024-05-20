using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [Header("Events")]
    [SerializeField] private IntEvent onMoneyValueChanged;
    [SerializeField] private ItemSOEvent onItemPicked;

    List<GameObject> foods = new List<GameObject>();

    public int money;

    private void OnEnable()
    {
        onMoneyValueChanged.AddListener(MoneyValueChange);
        onItemPicked.AddListener(AddItemList);
    }
    private void OnDisable()
    {
        onMoneyValueChanged.RemoveListener(MoneyValueChange);
        onItemPicked.RemoveListener(AddItemList);
    }

    private void MoneyValueChange(int deger)
    {
        money += deger;
    }

    private void AddItemList(ItemSO item)
    {
        foods.Add(item.prefab);
    }

    public void BaslaButton()
    {
        SceneManager.LoadScene(1);
    }
}
