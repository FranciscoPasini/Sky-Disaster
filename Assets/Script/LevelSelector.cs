using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.Rendering.VirtualTexturing.Debugging;
using UnityEngine.SceneManagement;
using System;
using Unity.VisualScripting;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class LevelSelector : MonoBehaviour
{
   
    public GameObject[] LevelButtons;
    public GameObject[] winIcon;
    
   
    int levelunlocked;
    



    private void Start()
    {
        Time.timeScale = 1.0f;

        int levelAt = PlayerPrefs.GetInt("levelAt", 0);
        levelunlocked = PlayerPrefs.GetInt("levelunlocked", 1);

        for (int i = 0; i < LevelButtons.Length; i++)
        {
            LevelButtons[i].SetActive(false);
        }

        for (int i = 0; i < winIcon.Length; i++)
        {
            winIcon[i].SetActive(false);
        }

        for (int i = 0; i < levelAt; i++)
        {
            winIcon[i].SetActive(true);
        }

        // Desbloqueo de niveles
        for (int i = 0; i < levelunlocked; i++)
        {
            
                LevelButtons[i].SetActive(true);
                  
        }
    }

    

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            PlayerPrefs.DeleteAll();

        }
    }

}