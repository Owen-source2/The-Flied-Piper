using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [Header("Stats")]
    public int honeyCollected = 0;
    public int pharaohAnnoyance = 10;

    [Header("UI")]
    public TextMeshProUGUI honeyText;
    public TextMeshProUGUI annoyanceText;
    public Slider honeyGauge, annoyanceGauge;

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
        UpdateUI();
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
        honeyGauge.value = honeyCollected;
        annoyanceGauge.value=pharaohAnnoyance;
    }
}