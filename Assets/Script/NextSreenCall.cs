using UnityEngine;
using UnityEngine.SceneManagement;

public class NextSreenCall : MonoBehaviour , IInteractable

{
    public void Interact()
    {
        SceneManager.LoadSceneAsync("GameScene");
    }
}
