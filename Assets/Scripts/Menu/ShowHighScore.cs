using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class ShowHighScore : MonoBehaviour
{
    private Text _highscoreText;
    private Player _player;
    
    void Start()
    {
        _highscoreText = GetComponent<Text>();
        _highscoreText.text = "HIGHSCORE: " + PlayerPrefs.GetInt("highScore");
    }
}
