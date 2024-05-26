using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private VoidEvent onStartAnimation;
    [SerializeField] private GameObject inputPanel;


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            inputPanel.GetComponent<Animator>().Play("AdGidis");
            Invoke("PlaySound", 0.25f);
            Invoke("InputActive", 0.8f);
        }
    }
    
    private void PlaySound()
    {
        AudioManager.Instance.PlaySFX("Anim");
    }
    private void InputActive()
    {
        inputPanel.SetActive(false);
    }
    public void BaslaButton()
    { 
        inputPanel.SetActive(true);
        AudioManager.Instance.PlaySFX("Anim");
    }
    public void CikisButton()
    {
        Debug.Log("Oyundan çýkýldý.");
        AudioManager.Instance.PlaySFX("Click");
        Application.Quit();
    }
}
