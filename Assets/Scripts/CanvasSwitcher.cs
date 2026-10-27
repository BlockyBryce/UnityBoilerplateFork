using UnityEngine;

public class CanvasSwitcher : MonoBehaviour
{
    [Header("Screens")]
    public GameObject mathCanvas;
    public GameObject tabletHomeCanvas;

    // Show the math minigame.
    public void OpenMathGame()
    {
        tabletHomeCanvas.SetActive(false);
        mathCanvas.SetActive(true);
    }

    // Show the placeholder home screen.
    public void BackToTabletHome()
    {
        mathCanvas.SetActive(false);
        tabletHomeCanvas.SetActive(true);
    }
}