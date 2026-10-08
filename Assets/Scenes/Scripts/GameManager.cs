using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public GameObject gameOverCanvas;
    public TextMeshProUGUI scoreText;
    private int score;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameOverCanvas.SetActive(false);
        scoreText.text = "Score: "+score;
    }

    public void AddScore()
    {
        score++;
        scoreText.text = "Score: "+score;
    }

    public void DoGameOver()
    {
        Time.timeScale = 0;
        gameOverCanvas.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
}
