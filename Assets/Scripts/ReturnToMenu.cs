using UnityEngine;
using UnityEngine.SceneManagement;

public class BadEnding : MonoBehaviour
{
    public AudioSource buttonSound;

    public void Play()
    {
        PlayClick();
        SceneManager.LoadScene(0);
    }

    private void PlayClick()
    {
        if (buttonSound != null)
        {
            buttonSound.Play();
        }
    }
}