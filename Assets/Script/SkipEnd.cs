using UnityEngine;

public class SkipEnd : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ExitGame();
        }
    }

    void ExitGame()
    {
    Application.Quit();
    UnityEditor.EditorApplication.isPlaying = false;
    }
}

