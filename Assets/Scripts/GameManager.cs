using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    [SerializeField] private TextMeshProUGUI CoinText;
    public GameUI gameUI;
    public int Coin = 0;

    private void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        CoinText.text = Coin.ToString();
        gameUI = FindAnyObjectByType<GameUI>();
    }

    public void AddScore(int points)
    {
        Coin += points;
        CoinText.text = Coin.ToString();
    }
}
