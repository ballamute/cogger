using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private bool gameHasEnded = false;
   
    public void EndGame(bool is_won)
    {
        if (gameHasEnded == false)
        {
            gameHasEnded = true;
            if (!is_won) ToEndScreen();
            else ToWinScreen();
        }
    }

    void ToWinScreen()
    {
        SceneManager.LoadScene("WinEndScreen");
    }

    void ToEndScreen()
    {
        SceneManager.LoadScene("EndScreen");
    }

    void Restart()
    {
        SceneManager.LoadScene("Level");
    }
}
