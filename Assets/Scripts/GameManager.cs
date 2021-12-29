using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public PlayerData bestPlayer;

    public PlayerData currentPlayer;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            bestPlayer = new PlayerData();
            currentPlayer = new PlayerData();

            LoadData();
        }
    }

    [Serializable]
    public class PlayerData
    {
        public string Username;

        public int BestScore;

        public override string ToString()
        {
            return $"Best Score : {Username} : {BestScore}";
        }
    }

    public void SaveData()
    {
        string json = JsonUtility.ToJson(bestPlayer);

        File.WriteAllText(Application.persistentDataPath + "/bestScore.json", json);
    }

    public void LoadData()
    {
        string path = Application.persistentDataPath + "/bestScore.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            bestPlayer = JsonUtility.FromJson<PlayerData>(json);
        }
    }

    private void OnApplicationQuit()
    {
        SaveData();
    }
}
