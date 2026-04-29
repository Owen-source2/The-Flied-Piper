using UnityEngine;
using UnityEngine.Audio;

public class HoneyCollectible : MonoBehaviour
{
    public int value = 1;
    public AudioSource collectclip;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Collect();
            collectclip.Play();
        }
    }

    void Collect()
    {
        GameManager.Instance.CollectHoney(value);
        Destroy(gameObject);
    }
}