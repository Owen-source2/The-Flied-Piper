using UnityEngine;

public class HoneyCollectible : MonoBehaviour
{
    public int value = 1;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Collect();
        }
    }

    void Collect()
    {
        GameManager.Instance.CollectHoney(value);
        Destroy(gameObject);
    }
}