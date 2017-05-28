using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicManager : MonoBehaviour {

    public AudioClip[] levelMusicArray;

    private AudioSource audioSource;

    void Awake () {
        DontDestroyOnLoad(gameObject);
        Debug.Log("Don't destroy on load: " + name);
    }

    void Start () {
        audioSource = GetComponent<AudioSource>();
        SceneManager.sceneLoaded += onLevelLoaded;
    }

    void onLevelLoaded(Scene scene, LoadSceneMode mode) {
        AudioClip levelMusic = levelMusicArray[scene.buildIndex];
        if (levelMusic) {
            Debug.Log("Playing clip: " + levelMusic);
            audioSource.clip = levelMusic;
            audioSource.loop = true;
            audioSource.Play();
        }

    }

}
