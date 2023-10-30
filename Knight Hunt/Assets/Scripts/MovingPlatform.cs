using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    [SerializeField] private Transform[] _waypoints;
    [SerializeField] private float _speed;
    [SerializeField] private float _checkDistance = 0.05f;

    private Transform _targetWaypoint;
    private int _currentWaypointIndex = 0;
    void Start()
    {
        
    }

    void Update()
    {
        transform.position = (Vector3)Vector2.MoveTowards(
            current: (Vector2)transform.position,
            (Vector2)_targetWaypoint.position,
            maxDistanceDelta: _speed * Time.deltaTime
            );

        if (Vector2.Distance(a:transform.position, b:_targetWaypoint.position) < _checkDistance)
        {
            _targetWaypoint = GetNextWaypoint();
        }
    }

    private Transform GetNextWaypoint()
    {
        _currentWaypointIndex++;
        if (_currentWaypointIndex >= _waypoints.Length)
        {
            _currentWaypointIndex = 0;
        }

        return _waypoints[_currentWaypointIndex];
    }
}
