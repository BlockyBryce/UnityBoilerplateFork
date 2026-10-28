using UnityEngine;
using UnityEngine.SceneManagement;

public class SendsUsertoDizzyMaze : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void GoToDizzyMaze()
    {
        SceneManager.LoadScene("MainMenu");
    }

    // Update is called once per frame
    void BackToMainGame()
    {
        SceneManager.LoadScene("Main Menu");
    }
}
