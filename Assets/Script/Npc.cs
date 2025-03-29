using UnityEngine;

public class Npc : MonoBehaviour, IInteractable
{
    public DialogBox dialogBox;

    public void Interact()
    {
        if (!dialogBox.gameObject.activeSelf)
        {
            dialogBox.StartDialogue();
        }
    }
}