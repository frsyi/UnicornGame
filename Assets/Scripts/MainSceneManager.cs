using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.SceneManagement;

public class MainSceneManager : MonoBehaviour
{
    public static MainSceneManager Instance;
    public int coin;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);

        LoadCoinData();
    }

    [Serializable]
    public class CoinData
    {
        public int coinX;
    }

    public void SaveCoinData()
    {
        CoinData data = new CoinData();
        data.coinX = coin;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadCoinData()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);

            CoinData data = JsonUtility.FromJson<CoinData>(json);
            coin = data.coinX;
        }
    }

    public void PlayGame()
    {
        SceneManager.LoadScene(1);
    }
}
