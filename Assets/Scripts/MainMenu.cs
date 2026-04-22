using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public AudioSource buttonSound;

    public void Play()
    {
        PlayClick();
        SceneManager.LoadScene(1);
    }

    public void Options()
    {
        PlayClick();
        Debug.Log("Options opened");
        SceneManager.LoadScene(2);
    }

    public void Quit()
    {
        PlayClick();
        Debug.Log("Quit");
        Application.Quit();
    }

    private void PlayClick()
    {
        if (buttonSound != null)
        {
            buttonSound.Play();
        }
    }
}
