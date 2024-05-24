using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private GameObject scoreBoardPanel;
    [SerializeField] private GameObject playerNamePanel;
    [SerializeField] private InputField inputField;

    public string isim;
    public void BaslaButton()
    {
        playerNamePanel.SetActive(true);
        inputField.onEndEdit.AddListener(OnInputFieldEndEdit);
    }
    public void CikisButton()
    {
        Debug.Log("Oyundan çýkýldý.");
        Application.Quit();
    }

    public void ScoreBoardButton(bool state)
    {
        scoreBoardPanel.SetActive(state);
    }

    public void StartLevel()
    {
        SceneManager.LoadScene(1);
    }

    private void OnInputFieldEndEdit(string input)
    {
        isim = input;
    }
}
