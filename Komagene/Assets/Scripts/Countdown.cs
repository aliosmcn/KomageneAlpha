using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting;

public class Countdown : MonoBehaviour
{
    public TextMeshProUGUI timerText;   //zaman texti
    public Image timerImg;              //timer fotosu
    public int currentTime;           //kalan zaman
    public int duration;              //toplam zamna

    int kalanDk;                      // toplam zamanýn 60a bölümünden kalan

    string hile = "";

    void Start()
    {
        currentTime = duration;
        timerText.text = currentTime.ToString();
        StartCoroutine(UpdateTime());
    }

    private IEnumerator UpdateTime()
    {
        while (currentTime >= 0)
        {
            timerImg.fillAmount = Mathf.InverseLerp(0, duration, currentTime);
            kalanDk = currentTime / 60;

            timerText.text = kalanDk.ToString("00") + ":" + (currentTime % 60).ToString("00");
            
            yield return new WaitForSeconds(1f);
            if (currentTime!=0)
            {
                currentTime--;
            }
        }
        yield return null;
    }
    private void Update()
    {
        if (Input.anyKeyDown)
        {
            hile += Input.inputString;

            
            if (hile == "aliosman")
            {
                currentTime += 30;      
                

                hile = "";          
            }

            if (Input.GetKeyDown(KeyCode.Return))
            {
                hile = "";
            }
        }
    }
}
