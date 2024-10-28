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
        SceneManager.LoadScene(0);
    }
}
