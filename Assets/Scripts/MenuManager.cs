using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    
    public string playerName;
    private DataManager dataManager;
    private void Start() 
    {
        dataManager = DataManager.instance;
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
