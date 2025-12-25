using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float _forwardSpeed = 5f;
    private float _laneDistance = 2f;

    private int _currentLane = 1; // 0 = Left, 1 = Middle, 2 = Right
    private bool _isAlive = true;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(!_isAlive) return;
        
        transform.Translate(Vector3.forward * _forwardSpeed * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
            ChangeLane(-1);
        if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
            ChangeLane(1);
    }

    void ChangeLane(int direction)
    {
        _currentLane = Mathf.Clamp(_currentLane + direction, 0, 2);
        float change = (_currentLane - 1) * _laneDistance;
        transform.position = new Vector3(change, transform.position.y, transform.position.z);
    }

    public void Die()
    {
        _isAlive = false;
    }
}
