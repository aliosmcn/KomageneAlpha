using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;
using UnityEngine.UI;

public class OrderSystem : MonoBehaviour
{
    int maxOrder = 3;
    int randomOrderIndex;

    public List<ItemSO> Orders;

    [SerializeField] private Sprite[] orderSprites;

    private void Start()
    {
        randomOrderIndex = Random.Range(0, Orders.Count);

        for (int i = 0; i < maxOrder; i++)
        {
            orderSprites[i] = Orders[randomOrderIndex].ItemIcon;
        }

    }
}
