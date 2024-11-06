using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class Play : MonoBehaviour
{
    public Button Play_Button;

    public void Play_Game()
    {
        PlayerPrefs.SetInt("P1", 0);
        PlayerPrefs.SetInt("P2", 0);
        SceneManager.LoadScene(2);
    }

    public void Play_Instruction()
    {
        SceneManager.LoadScene(1);
    }

    public void Game_Start()
    {
        SceneManager.LoadScene(0);
    }
}
