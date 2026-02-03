using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    private Text _scoreText;
    private Text _bestScoreText;

    private Text _gameOverScoreText;
    private Text _gameOverBestScoreText;

    // Start is called before the first frame update
    void Start()
    {
        _scoreText = transform.GetChild(0).GetComponent<Text>();
        if (_scoreText == null)
        {
            Debug.LogError("Score Text component not found. Please ensure the first child has a Text component.");
        }

        _bestScoreText = transform.GetChild(1).GetComponent<Text>();
        if (_bestScoreText == null)
        {
            Debug.LogError("Best Score Text component not found. Please ensure the second child has a Text component.");
        }

        _gameOverScoreText = transform.GetChild(2).GetChild(0).GetComponent<Text>();
        if (_gameOverScoreText == null)
        {
            Debug.LogError("Game Over Score Text component not found. Please ensure the GameOverPanel's first child has a Text component.");
        }

        _gameOverBestScoreText = transform.GetChild(2).GetChild(1).GetComponent<Text>();
        if (_gameOverBestScoreText == null)
        {
            Debug.LogError("Game Over Best Score Text component not found. Please ensure the GameOverPanel's second child has a Text component.");
        }
        _scoreText.text = "Score: ";
        _bestScoreText.text = "Best Score: " + PlayerPrefs.GetFloat("BestScore", 0).ToString();
    }

    // Updates the in-game score and best score UI
    public void UpdateText(float score, float bestScore)
    {
        _scoreText.text = "Score: " + score.ToString();
        _bestScoreText.text = "Best Score: " + bestScore.ToString();
    }

    // Updates the Game Over panel texts using current score values
    public void UpdateGameOverText()
    {
        _gameOverScoreText.text = "Score: " + _scoreText.text.Substring(7);
        _gameOverBestScoreText.text = "Best Score: " + _bestScoreText.text.Substring(12);
    } 
}
