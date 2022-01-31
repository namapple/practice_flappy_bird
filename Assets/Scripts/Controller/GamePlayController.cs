using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GamePlayController : MonoBehaviour
{
    public static GamePlayController instance;
    [SerializeField]
    private Button instructionButton;
    [SerializeField]
    private Button pauseButtonController;
    private Button controller;
    [SerializeField]
    private Text scoreText, endScoreText, bestScoreText;
    [SerializeField]
    private GameObject gameOverPanel;
    [SerializeField]
    private GameObject pausePanel;
    private void Awake()
    {
        MakeInstance();
        Time.timeScale = 0;
    }

    void MakeInstance()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    public void InstructionButton()
    {
        Time.timeScale = 1;
        // khai bao la kieu  Button, muon show/hide,
        // phai thong qua gameObject
        instructionButton.gameObject.SetActive(false);
    }

    public void SetScore(int score)
    {
        scoreText.text = "" + score;
    }

    public void BirdDiedShowPanel(int score)
    {
        // Khai bao thang la game object roi
        //nen khong can thong qua gameObject
        gameOverPanel.SetActive(true);
        endScoreText.text = "" + score;
        if (score > GameManager.instance.GetHighScore())
        {
            GameManager.instance.SetHighScore(score);
        }

        bestScoreText.text = "" + GameManager.instance.GetHighScore();
    }

    public void RestartButton()
    {
        SceneManager.LoadScene("GamePlay");
    }
    public void MenuButton()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void PauseButtonController()
    {
        pauseButtonController.gameObject.SetActive(false);
    }
    public void PauseButton()
    {
        Time.timeScale = 0;
        pauseButtonController.gameObject.SetActive(false);
        pausePanel.SetActive(true);
    }
    public void ResumeButton()
    {
        Time.timeScale = 1;
        pauseButtonController.gameObject.SetActive(true);
        pausePanel.SetActive(false);
    }
}
