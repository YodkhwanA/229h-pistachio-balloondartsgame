using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class RestartGame : MonoBehaviour
{
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        print("it work");
    }
}
