using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject[] players;
    public int map = 1;
    private int scoreP1;
    private int scoreP2;

    public TMP_Text scoreP1Text;
    public TMP_Text scoreP2Text;

    bool isPlayer1Alive = false;
    bool isPlayer2Alive = false;

    public void Start()
    {
        scoreP1 = PlayerPrefs.GetInt("P1", 0);
        scoreP2 = PlayerPrefs.GetInt("P2", 0);
        UpdateScore(scoreP1, scoreP2);
    }
    public void CheckWinState()
    {
        int aliveCount = 0;
        foreach (GameObject player in players)
        {
            if (player.activeSelf)
            {
                aliveCount++;
                if (player.CompareTag("Player1"))
                {
                    isPlayer1Alive = true;
                }
                else if (player.CompareTag("Player2"))
                {
                    isPlayer2Alive = true;
                }
            }
        }

        if (!isPlayer1Alive && isPlayer2Alive)
        {
            scoreP2++;
            PlayerPrefs.SetInt("P2", scoreP2);
            UpdateScore(scoreP1, scoreP2);
        }
        else if (!isPlayer2Alive && isPlayer1Alive)
        {
            scoreP1++;
            PlayerPrefs.SetInt("P1", scoreP1);
            UpdateScore(scoreP1, scoreP2);
        }

        if (scoreP1 > scoreP2)
        {
            PlayerPrefs.SetString("PlayerWin", "Player1 Win");
        }
        else if (scoreP2 > scoreP1)
        {
            PlayerPrefs.SetString("PlayerWin", "Player2 Win");
        }

        if (aliveCount <= 1)
        {
            Invoke(nameof(NewRound), 3f);
            
        }
    }

    private void NewRound()
    {
        SceneManager.LoadScene(map);
    }

    public void UpdateScore(int scoreP1, int scoreP2)
    {
        scoreP1Text.text = scoreP1.ToString();
        scoreP2Text.text = scoreP2.ToString();
    }
    private void OnApplicationQuit()
    {
        PlayerPrefs.DeleteKey("P1");
        PlayerPrefs.DeleteKey("P2");
    }
}
