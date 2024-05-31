using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    private int coinCount = 0;
    [SerializeField] private TextMeshProUGUI CoinCountText;

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
    }

    public void AddCoin()
    {
        coinCount++;
        UpdateCoinCountText();
    }

    private void UpdateCoinCountText()
    {
        if (CoinCountText != null)
        {
            CoinCountText.text = coinCount.ToString();
        }
    }
}