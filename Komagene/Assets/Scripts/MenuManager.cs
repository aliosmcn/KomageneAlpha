using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private Animator gecisAnim;
    [SerializeField] private GameObject animPanel;
    [SerializeField] private GameObject scoreBoardPanel;
    [SerializeField] private GameObject playerNamePanel;
    [SerializeField] private InputField inputField;

    public void BaslaButton()
    {
        animPanel.SetActive(true);
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
        string name = input;
    }
}
