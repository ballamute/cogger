using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiHealth : MonoBehaviour
{
    private Player player;
    private int player_health;
    private Image heart_1, heart_2, heart_3;

    public List<GameObject> hearts;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player").GetComponent<Player>();
        heart_1 = hearts[0].GetComponent<Image>();
        heart_2 = hearts[1].GetComponent<Image>();
        heart_3 = hearts[2].GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        player_health = player.health;
        if (player_health == 3)
        {
            heart_1.enabled = true;
            heart_2.enabled = true;
            heart_3.enabled = true;
        }
        else if (player_health == 2)
        {
            heart_1.enabled = true;
            heart_2.enabled = true;
            heart_3.enabled = false;
        }
        else if (player_health == 1)
        {
            heart_1.enabled = true;
            heart_2.enabled = false;
            heart_3.enabled = false;
        }
        else if (player_health <= 0)
        {
            heart_1.enabled = false;
            heart_2.enabled = false;
            heart_3.enabled = false;
        }
    }
}
