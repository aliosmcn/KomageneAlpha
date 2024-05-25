using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using static UnityEngine.Rendering.DebugUI;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private GameObject inputPanel;
    
    public void BaslaButton()
    {
        inputPanel.SetActive(true);
    }
    public void CikisButton()
    {
        Debug.Log("Oyundan çýkýldý.");
        Application.Quit();
    }
}
