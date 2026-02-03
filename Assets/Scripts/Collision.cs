using UnityEngine;

public class Collision : MonoBehaviour
{
    // Reference to the GameManager
    private GameManager _gameManager;

    // Start is called before the first frame update
    void Start()
    {
        _gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        if (_gameManager == null)
        {
            Debug.LogError("GameManager object not found in the scene. Please ensure there is a GameObject with GameManager script attached.");
        }
    }

    // Called when this collider enters a trigger collider
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Obstacle"))
        {
            _gameManager.GameOver();
        }
    }
}
