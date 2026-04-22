using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [Header("Stats")]
    public int honeyCollected = 0;
    public int pharaohAnnoyance = 10;
    public int annoyThreshold=5;

    [Header("UI")]
    public TextMeshProUGUI honeyText;
    public TextMeshProUGUI annoyanceText;
    public float timer=10.0f;
    private float timerInit;

    private void Awake()
    {
        // Singleton setup
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        timerInit=timer;
    }
    void Update()
    {
        timer-=Time.deltaTime;
        if (timer <= 0)
        {
            UpdateAnnoyanceAndHoney();
            timer=timerInit;
        }
    }

    public void CollectHoney(int amount)
    {
        honeyCollected += amount;
        pharaohAnnoyance -= amount;

        UpdateUI();
    }

    void UpdateUI()
    {
        honeyText.text = "Honey: " + honeyCollected;
        annoyanceText.text = "Pharaoh Annoyance: " + pharaohAnnoyance;
    }
    void UpdateAnnoyanceAndHoney()
    {
        honeyCollected-=1;
        if (honeyCollected <= annoyThreshold)
        {
            pharaohAnnoyance+=1;
        }
        else
        {
            pharaohAnnoyance-=1;
        }
        UpdateUI();
    }
}