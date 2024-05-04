using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using UnityEngine;
using static UnityEditor.Progress;

public class Combiner : MonoBehaviour
{

    [SerializeField] private ItemSO currentPlateObject;
    GameObject temas;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag != "item") return;
        ItemSO itemso = collision.gameObject.GetComponent<Item>().ItemData;
        if (itemso.ItemID.StartsWith("T"))
        {
            return;
        }
        temas = collision.gameObject;
        SearchRecipe(itemso.ItemID);
    }


    private void SearchRecipe(string itemid)
    {
        Debug.Log("a" + itemid + " : " + currentPlateObject.ItemID);
        ItemSO toCraftitemSO = CraftingMech.Instance.SearchRecipes(itemid, currentPlateObject.ItemID);
        if (toCraftitemSO == null) return;
        GameObject toInstantiate = Instantiate(toCraftitemSO.prefab);
        toInstantiate.transform.position = transform.position;

        Destroy(temas);
        Destroy(this.gameObject);
        return;
    }

}
