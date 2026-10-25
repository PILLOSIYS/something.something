using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    [Header("Game Rules")]
    [SerializeField] private int totalCollectibles = 6;

    [Header("UI References")]
    [SerializeField] private TMP_Text scoreText;
    [SerializeField] private GameObject winPanel;

    public int Score { get; private set; }
    public bool IsGameOver { get; private set; }

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        if (winPanel != null) winPanel.SetActive(false);
        UpdateScoreUI();
    }

    public void AddScore(int amount)
    {
        if (IsGameOver) return;

        Score += amount;
        UpdateScoreUI();

        if (Score >= totalCollectibles) Win();
    }

    private void Win()
    {
        IsGameOver = true;
        if (winPanel != null) winPanel.SetActive(true);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void UpdateScoreUI()
    {
        if (scoreText != null)
            scoreText.text = $"collected: {Score} / {totalCollectibles}";
    }
}