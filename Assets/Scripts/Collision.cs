using UnityEngine;

public class Collision : MonoBehaviour
{
    private GameManager _gameManager;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        if (_gameManager == null)
        {
            Debug.LogError("GameManager object not found in the scene. Please ensure there is a GameObject with GameManager script attached.");
        }
    }

    // Update is called once per frame
    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Obstacle"))
        {
            _gameManager.GameOver();
        }
    }
}
