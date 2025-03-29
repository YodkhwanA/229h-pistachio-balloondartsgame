using UnityEngine;
using TMPro;
using System.Collections;
using UnityEngine.SceneManagement;

public class DialogBox : MonoBehaviour
{
    public TextMeshProUGUI textComponent;
    public string[] lines;
    public float textSpeed;
    private int index;
    public GameObject dialogPanel;
    private bool isTalking = false;

    void Start()
    {
        textComponent.text = string.Empty;
        dialogPanel.SetActive(false);
    }

    void Update()
    {
        if (!isTalking) return;

        if (Input.GetMouseButtonDown(0))
        {
            if (textComponent.text == lines[index])
            {
                NextLine();
            }
            else
            {
                StopAllCoroutines();
                textComponent.text = lines[index];
            }
        }
    }

    public void StartDialogue()
    {
        if (isTalking) return;
        dialogPanel.SetActive(true);
        isTalking = true;
        index = 0;
        textComponent.text = string.Empty;
        StartCoroutine(TypeLine());
    }

    IEnumerator TypeLine()
    {
        foreach (char c in lines[index].ToCharArray())
        {
            textComponent.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
    }

    void NextLine()
    {
        if (index < lines.Length - 1)
        {
            index++;
            textComponent.text = string.Empty;
            StartCoroutine(TypeLine());
        }
        else
        {
            EndDialogue();
        }
    }

    void EndDialogue()
    {
        dialogPanel.SetActive(false);
        isTalking = false;

        if (index >= lines.Length - 1)
        {
            SceneManager.LoadSceneAsync("GameScene");
        }
    }
}

public class NPC : MonoBehaviour, IInteractable
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
