using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GameUI : MonoBehaviour
{
    [SerializeField] private GameObject gameOverUI;
    [SerializeField] private GameObject pauseUI;
    [SerializeField] private TextMeshProUGUI coinText;
    [SerializeField] private Image coinImage;
    [SerializeField] private TextMeshProUGUI gameOverDistanceTraveled;
    private Player player;
    private AudioManager audioManager;

    void Start()
    {
        player = FindAnyObjectByType<Player>();
        audioManager = FindAnyObjectByType<AudioManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (pauseUI.activeSelf)
            {
                StartGameUI();
            }
            else
            {
                StartPauseUI();
            }
        }
    }

    void setCoinPos(float pos)
    {
        // Lấy RectTransform của text
        RectTransform rect = coinText.GetComponent<RectTransform>();
        rect.localPosition = new Vector3(0, pos, 0);
        rect = coinImage.GetComponent<RectTransform>();
        rect.localPosition = new Vector3(-100, pos, 0);
    }

    public void StartPauseUI()
    {
        Time.timeScale = 0;
        setCoinPos(40);
        gameOverUI.SetActive(false);
        pauseUI.SetActive(true);
    }

    public void StartGameUI()
    {
        Time.timeScale = 1;
        setCoinPos(400);
        gameOverUI.SetActive(false);
        pauseUI.SetActive(false);
    }

    public void StartGameOverUI()
    {
        audioManager.PlayGameOverSound();
        Time.timeScale = 0;
        setCoinPos(40);
        // player
        gameOverDistanceTraveled.text = "Distance Traveled: " + Mathf.FloorToInt(player.transform.position.z / 10).ToString() + "m";
        gameOverUI.SetActive(true);
        pauseUI.SetActive(false);
    }

    public void ReStartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1;
    }

}
