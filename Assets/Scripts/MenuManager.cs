using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public TextMeshProUGUI highScoreText;    
    public string playerName;
    private DataManager dataManager;
    
    private void Start() 
    {
        dataManager = DataManager.instance;
        UpdateUI();
    }

    private void UpdateUI()
    {
        highScoreText.text = "Best Score: " + dataManager.highScoreName + " : " + dataManager.highScoreValue;
    }

    public void ReadStringInput(string input)
    {
        playerName = input;
    }

    public void StartGame()
    {
        dataManager.SetPlayerName(playerName);
        SceneManager.LoadScene(1);
    }
    
    public void Quit()
    {
        Application.Quit();
    }

}
