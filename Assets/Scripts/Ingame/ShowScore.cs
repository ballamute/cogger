using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShowScore : MonoBehaviour
{
    private Text _scoreText;
    private Player _player;
    private String _toWin;
    // Start is called before the first frame update
    void Start()
    {
        _scoreText = GetComponent<Text>();
        _player = GameObject.FindWithTag("Player").GetComponent<Player>();
        _toWin = _player.scoreToWIn.ToString();
        _scoreText.text = _player.score + " / " + _toWin;
    }

    // Update is called once per frame
    void Update()
    {
        _scoreText.text = _player.score + " / " + _toWin;
    }
}
