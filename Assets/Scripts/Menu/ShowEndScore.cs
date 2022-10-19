using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ShowEndScore : MonoBehaviour
{
    private Text _scoreText;
    private Player _player;

    void Start()
    {
        _scoreText = GetComponent<Text>();
        _scoreText.text = "SCORE: " + PlayerPrefs.GetInt("lastScore");
    }

}
