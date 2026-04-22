using UnityEngine;
using TMPro;
using System.Collections;
public class PharohDialogue : MonoBehaviour
{
    public bool isMad,isHappy;
    public TMP_Text dialogBox;
    public string[] happyLines;
    public string[] madLines;
    public float textPersist,textCooldown;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void SelectLine()
    {
        //Checks pharoh mood, plays random line from appropriate array, defined in engine
        if (isMad)
        {
            dialogBox.text=madLines[Random.Range(0,madLines.Length)];
        }
        else
        {
            dialogBox.text=happyLines[Random.Range(0,happyLines.Length)];
        }
        ClearLine();
    }    
    void Start()
    {
        //Plays random lines on set interval, defined in engine
        InvokeRepeating(nameof(SelectLine),textCooldown,textCooldown);
    }
    void Update()
    {
        //Determine pharoh's mood for line selection
        if (GameManager.Instance.pharaohAnnoyance >= 5)
        {
            isMad=true;
            isHappy=false;
        }
        else
        {
            isHappy=true;
            isMad=false;
        }
    }
    IEnumerator ClearLine()
    {
        //Waits a certain amount of time, before clearing text box
        yield return new WaitForSeconds(textPersist);
        dialogBox.text = null;
    }

}
