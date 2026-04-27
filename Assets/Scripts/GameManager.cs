using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [Header("Stats")]
    public int honeyCollected = 0,maxHoney=10;
    public int pharaohAnnoyance = 10,maxAnnoyance=10;
    public int annoyThreshold=5;

    [Header("UI")]
    public TextMeshProUGUI honeyText;
    public TextMeshProUGUI annoyanceText;
    public Slider honeyGauge, annoyGauge;
    public float timer=10.0f,gameTime=150.0f;
    private float timerInit,gameTimeInit;

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
        gameTimeInit=gameTime;
        UpdateUI();
    }
    void Update()
    {
        timer-=Time.deltaTime;
        if (timer <= 0)
        {
            UpdateAnnoyanceAndHoney();
            timer=timerInit;
        }
        gameTime-=Time.deltaTime;
        if (gameTime <= 0)
        {
            EndGame();
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
        honeyGauge.value=honeyCollected;
        annoyGauge.value=pharaohAnnoyance;
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
    void EndGame()
    {
        if (pharaohAnnoyance <= maxAnnoyance)
        {
            PlayGoodEnd();
        }
        else
        {
            PlayBadEnd();
        }
    }
    void PlayGoodEnd()
    {
        print("Good End");
    }
    void PlayBadEnd()
    {
        print("BadEnd");
    }
}