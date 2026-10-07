using Unity.VectorGraphics;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    //OBS I deleted the start and update the function
    public void GoToLevel()
    {
        //Level 1 is the name of the other 
        //for this to work, level1 is added
        SceneManager.LoadScene("level1");
    }
    public void Exit()
    {
        Application.Quit();
    }
}
