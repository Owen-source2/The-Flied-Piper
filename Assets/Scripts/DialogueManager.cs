using UnityEngine;
using UnityEngine.Events;
using Yarn.Unity;

public class DialogueManager : MonoBehaviour
{
    public static DialogueManager dman;
    public DialogueRunner dialogueRunner;
    private bool dialogReady,dialogStarted;
    public UnityAction DialogStart,DialogOver;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        if (dman == null)
        {
            dman=this;
        }
    }

    // Update is called once per frame
    void SelectLine()
    {
        
    }
    public void StartDialog()
    {
        if (dialogReady && !dialogStarted)
        {

            // just to be careful make sure the runner is stopped
            dialogueRunner.Stop();

            dialogueRunner.StartDialogue(dialogueRunner.startNode);
            if (DialogStart != null)
                DialogStart();

            dialogStarted = true;
            print(dialogStarted);
        }
    }
    public void OnDialogOver()
    {
        if (DialogStart != null)
            DialogOver();

        dialogStarted = false;
    }
    

}
