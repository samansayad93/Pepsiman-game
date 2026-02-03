using System.Threading;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private GameObject _gameOverPanel;

    private UIManager _uiManager;

    private GameObject _player;

    private GameObject _ground;

    private float _score = 0;

    private float _bestScore = 0;

    private float _timer = 0f;

    void Start()
    {
        _gameOverPanel = GameObject.Find("Canvas/GameOverPanel");
        if (_gameOverPanel == null)
        {
            Debug.LogError("GameOverPanel not found in the scene. Please ensure there is a GameObject named 'GameOverPanel' under 'Canvas'.");
        }

        _uiManager = GameObject.Find("Canvas").GetComponent<UIManager>();
        if (_uiManager == null)
        {
            Debug.LogError("UIManager component not found on Canvas. Please ensure the Canvas has a UIManager script attached.");
        }

        _player = GameObject.FindWithTag("Player");
        if (_player == null)
        {
            Debug.LogError("Player object with tag 'Player' not found in the scene.");
        }

        _ground = GameObject.Find("Ground");
        if (_ground == null)
        {
            Debug.LogError("Ground object not found in the scene.");
        }

        _bestScore = PlayerPrefs.GetFloat("BestScore", 0);

        _gameOverPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        _timer += Time.deltaTime;

        if (_timer >= 1f)
        {
            _score += 10;
            _timer = 0f;
        }

        if (_score > _bestScore)
        {
            _bestScore = _score;
            PlayerPrefs.SetFloat("BestScore", _bestScore);
        }

        _uiManager.UpdateText(_score, _bestScore);

        _ground.transform.position = new Vector3(0,0,(Mathf.Floor(_player.transform.position.z / 300) * 300) + 200);
    }

    // Called when the player hits an obstacle
    public void GameOver()
    {
        _gameOverPanel.SetActive(true);
        _player.GetComponent<PlayerController>().GameOver();
        _uiManager.UpdateGameOverText();
        Time.timeScale = 0;
    }

    // Restart the game from the beginning
    public void RestartGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
