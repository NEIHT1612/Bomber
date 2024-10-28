using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class StateWin : MonoBehaviour
{
    public TMP_Text myStateGame;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        myStateGame.text = PlayerPrefs.GetString("PlayerWin", "Player Win");
    }
}
