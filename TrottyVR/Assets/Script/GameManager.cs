using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    private int coinCount = 0;
    [SerializeField] private TextMeshProUGUI coinCountText;  // Reference to the coin count text
    [SerializeField] private TextMeshProUGUI timerText;      // Reference to the timer text

    private float timer = 0f;
    private bool isTiming = true;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        UpdateCoinCountText();
        UpdateTimerText();
    }

    private void Update()
    {
        if (isTiming)
        {
            timer += Time.deltaTime;
            UpdateTimerText();
        }
    }

    public void AddCoin()
    {
        coinCount++;
        Debug.Log("Number of coins: " + coinCount);
        UpdateCoinCountText();

        if (coinCount >= 10)
        {
            StopTimer();
        }
    }

    private void UpdateCoinCountText()
    {
        if (coinCountText != null)
        {
            coinCountText.text = "Coins: " + coinCount.ToString();
        }
    }

    private void UpdateTimerText()
    {
        if (timerText != null)
        {
            timerText.text = "Time: " + timer.ToString("F2") + "s";
        }
    }

    private void StopTimer()
    {
        isTiming = false;
    }
}


