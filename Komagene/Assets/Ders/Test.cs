using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    /*
    int s1 = 21;
    int s2 = 10;
    int s3;
    string isim = "ali";
    bool erkek = false;
    float sayi = 250f;
    */

    public GameObject kup;
    //string isim = "Ali";
    
    [SerializeField] private float moveSpeed;
    string[] Sehirler = {"Nevþehir", "Ankara", "Ýstanbul", "Giresun"};

    void Start()
    {
        // Fonk(s1, isim);
        DiziYazdir();
    }


    void Update()
    {
        kup.transform.position = new Vector3(0, 0, kup.transform.position.z + moveSpeed * Time.deltaTime);
    }

    void Fonk(int yas, string isim)
    {
        for (int i = 0; i < yas; i++)
        {
            Debug.Log(isim + " - "+ yas);
        }
        
    }

    void DiziYazdir()
    {
        foreach (string item in Sehirler)
        {
            Debug.Log(item);
            if (item == "Ýstanbul")
            {
                Debug.Log("Þehir bulundu");
                break;
            }
        }
    }
}
