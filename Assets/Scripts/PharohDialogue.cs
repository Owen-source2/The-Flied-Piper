using UnityEngine;

public class PharohDialogue : MonoBehaviour
{
    public bool isMad,isHappy;

    public string[] happySayings;
    public string[] madLines;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void SelectLine()
    {
        
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
}
