using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [Header("Stats")]
    public int honeyCollected = 0,maxHoney=10;
    public int pharaohAnnoyance = 10,maxAnnoyance=10;
    public int annoyThreshold=5;

    [Header("UI")]
    public TextMeshProUGUI honeyText;
    public TextMeshProUGUI annoyanceText,timerReadout;
    public Slider honeyGauge, annoyGauge;
    public float timer=10.0f,gameTime=150.0f;
    private float timerInit,gameTimeInit;
    private bool gameOver;

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
        //gameTimeInit=gameTime;
        UpdateUI();
    }
    void Update()
    {
        timer-=Time.deltaTime;
        //print(timer);
        if (timer <= 0)
        {
            AnnoyPharaoh();
            timer=timerInit;
        }
        gameTime-=Time.deltaTime;
        if (gameTime <= 0&&!gameOver)
        {
            EndGame();
        }
        UpdateUI();
    }

    public void CollectHoney(int amount)
    {
        honeyCollected += amount;
        pharaohAnnoyance -= amount;
        timer=timerInit;
        UpdateUI();
    }

    void UpdateUI()
    {
        timerReadout.text=Mathf.FloorToInt(gameTime).ToString();
        honeyText.text = "Honey: " + honeyCollected;
        annoyanceText.text = "Pharaoh Annoyance: " + pharaohAnnoyance;
        honeyGauge.value=honeyCollected;
        annoyGauge.value=pharaohAnnoyance;
    }
    void AnnoyPharaoh()
    {
        pharaohAnnoyance++;
        UpdateUI();
    }
    void EndGame()
    {
        gameOver=true;
        if (pharaohAnnoyance <= annoyThreshold)
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
        SceneManager.LoadScene(3);
    }
    void PlayBadEnd()
    {
        print("BadEnd");
        SceneManager.LoadScene(4);
    }
}