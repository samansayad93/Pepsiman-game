using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    private Text _scoreText;
    private Text _bestScoreText;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
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
        _scoreText.text = "Score: ";
        _bestScoreText.text = "Best Score: " + PlayerPrefs.GetFloat("BestScore", 0).ToString();
    }

    // Update is called once per frame
    public void UpdateText(float score, float bestScore)
    {
        _scoreText.text = "Score: " + score.ToString();
        _bestScoreText.text = "Best Score: " + bestScore.ToString();
    }
}
