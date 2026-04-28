using UnityEngine;
using UnityEngine.SceneManagement;

public class StoryScene : MonoBehaviour
{
    public AudioSource buttonSound;

    public void Play()
    {
        PlayClick();
        SceneManager.LoadScene(2);
    }

    private void PlayClick()
    {
        if (buttonSound != null)
        {
            buttonSound.Play();
        }
    }
}