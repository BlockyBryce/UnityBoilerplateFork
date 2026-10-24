using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // The difficulty selected by the player.
    // 0 = On The Clock
    // 1 = Beat The Clock
    // 2 = Overclocked
    public static int SelectedDifficulty = 0;

    // Opens the Difficulty Screen.
    public void StartGame()
    {
        SceneManager.LoadScene("Difficulty Screen");
    }

    // Opens the Settings Screen.
    // You can create this scene later.
    public void OpenSettings()
    {
        SceneManager.LoadScene("Settings");
    }

    // Closes the game.
    public void QuitGame()
    {
        Debug.Log("Quitting game!");

        Application.Quit();
    }

    // Returns to the Main Menu.
    public void BackToMainMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }

    // Starts the game on On The Clock difficulty.
    public void SelectOnTheClock()
    {
        StartWithDifficulty(0);
    }

    // Starts the game on Beat The Clock difficulty.
    public void SelectBeatTheClock()
    {
        StartWithDifficulty(1);
    }

    // Starts the game on Overclocked difficulty.
    public void SelectOverclocked()
    {
        StartWithDifficulty(2);
    }

    // Saves the chosen difficulty and loads the game.
    private void StartWithDifficulty(int difficulty)
    {
        SelectedDifficulty = difficulty;

        Debug.Log("Selected difficulty: " + difficulty);

        SceneManager.LoadScene("Office");
    }
}
