using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    public string playerName;

    [Header("High Score")]
    public string highScoreName;
    public int highScoreValue;
    

    #region Instance

    public static DataManager instance;

    private void Awake() 
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    #endregion  
    
    private void Start() 
    {
        LoadScore();
    }

    public void SetPlayerName(string name)
    {
        playerName = name;
    }

    public void SetHighScore(int value)
    {
        highScoreName = playerName;
        highScoreValue = value;
        SaveScore();
    }

    private void SaveScore()
    {
        SaveData data = new SaveData();
        data.playerName = highScoreName;
        data.highScore = highScoreValue;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    private void LoadScore()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            highScoreName = data.playerName;
            highScoreValue = data.highScore;
        }
    }


    [System.Serializable]
    class SaveData
    {
        public string playerName;
        public int highScore;
    }

}
