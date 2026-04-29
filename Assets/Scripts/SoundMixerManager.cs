using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SoundMixerManager : MonoBehaviour
{
    [SerializeField] private AudioMixer audioMixer;
    [SerializeField] private Slider masterSlider;
    [SerializeField] private Slider musicSlider;
    [SerializeField] private Slider sfxSlider;

    void Start()
    {
        masterSlider.value = PlayerPrefs.GetFloat("Master", 1f);
        musicSlider.value  = PlayerPrefs.GetFloat("Music",  1f);
        sfxSlider.value    = PlayerPrefs.GetFloat("SFX",    1f);
    }

    public void SetMaster(float val)
    {
        Set("Master", val);
    }

    public void SetMusic(float val)
    {
        Set("Music", val);
    }

    public void SetSFX(float val)
    {
        Set("SFX", val);
    }

    private void Set(string param, float val)
    {
        audioMixer.SetFloat(param, Mathf.Log10(val) * 20f);
        PlayerPrefs.SetFloat(param, val);
        PlayerPrefs.Save();
    }
}
