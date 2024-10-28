using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Play : MonoBehaviour
{
    public Button Play_Button;

    public void Play_Game()
    {
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
