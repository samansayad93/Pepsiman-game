using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject _obstaclePrefab;
    private Transform _playerTransform;

    private float _spawnZ = 5f;
    private float _nextSpawnZ;

    private float _minDistance = 3f;
    private float _maxDistance = 7f;
    private float laneDistance = 2f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        if (_playerTransform == null)
        {
            Debug.LogError("Player object not found in the scene. Please ensure there is a GameObject tagged 'Player'.");
        }
        _nextSpawnZ = _spawnZ;
    }

    // Update is called once per frame
    void Update()
    {
        if (_playerTransform.position.z + _spawnZ > _nextSpawnZ)
        {
            SpawnObstacle();
            _nextSpawnZ += Random.Range(_minDistance, _maxDistance);
        }
    }

    void SpawnObstacle()
    {
        int lane = Random.Range(0, 3); // 0 = Left, 1 = Middle, 2 = Right
        float spawnX = (lane - 1) * laneDistance;
        Vector3 spawnPosition = new Vector3(spawnX, 0.5f, _nextSpawnZ);
        GameObject obstacle = Instantiate(_obstaclePrefab, spawnPosition, Quaternion.identity);
        obstacle.transform.parent = transform;
    }
}
