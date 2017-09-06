using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEngine.SceneManagement;

public class GameControl : MonoBehaviour {

    public static GameControl control;

    private string fileName;
    private bool savedGameExists = false;

    void Awake()
    {
        if(control == null)
        {
            DontDestroyOnLoad(gameObject);
            control = this;
        }
        else if (control != this)
        {
            Destroy(gameObject);
        }

        fileName = Application.persistentDataPath + "/playerData.dat";

        if (File.Exists(fileName))
        {
            savedGameExists = true;
        }
    }

    void Start()
    {
        Debug.Log("Has Saved Game: " + savedGameExists);
    }

    void OnEnable()
    {
        SceneManager.activeSceneChanged += Save;
    }

    void OnDisable()
    {
        SceneManager.activeSceneChanged -= Save;
    }

    public bool hasSavedGame()
    {
        return savedGameExists;
    }

    public void Save(Scene previousScene, Scene newScene)
    {
        if (newScene.name == "Main Map")
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Create(fileName);

            PlayerData data = new PlayerData(PlayerStats.playerStats);

            bf.Serialize(file, data);
            file.Close();

            Debug.Log("Game Saved Successfully!");
        }        
    }

    public void Load()
    {
        if (savedGameExists)
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(fileName, FileMode.Open);
            PlayerData data = (PlayerData)bf.Deserialize(file);
            file.Close();

            PlayerStats.playerStats = data.getPlayerStats();
        }
        
    }

}

[Serializable] // Doesn't work yet.. :(
class PlayerData
{
    PlayerStats stats;

    public PlayerData(PlayerStats stats)
    {
        this.stats = stats;
    }

    public PlayerStats getPlayerStats()
    {
        return stats;
    }

}