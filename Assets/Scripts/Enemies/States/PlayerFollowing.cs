using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class PlayerFollowing : IState
{
    // External Attributes
    private Seeker _seeker;
    private Transform _playerPos;
    private float _speed;
    private float _nextWayPointDistance;

    // Internal Attributes
    private Path _path;
    private int _currentWayPoint = 0;
    private bool _reachedEndOfPath = false;
    private float _updateTimer = 0.0f;

    public PlayerFollowing(Seeker seeker, Transform playerPos, float speed, float nextWayPointDistance)
    {
        _seeker = seeker;
        _playerPos = playerPos;
        _speed = speed;
        _nextWayPointDistance = nextWayPointDistance;
    }

    public void OnEnter()
    {
        _seeker.StartPath(_seeker.transform.position, _playerPos.position, OnPathComplete);
    }

    public void OnExit()
    {
        // Nothing for now
    }

    public void Tick()
    {
        if (_path == null)
            return;

        if (_currentWayPoint >= _path.vectorPath.Count)
        {
            _reachedEndOfPath = true;
            UpdateFollowPlayerPath();
            return;
        }
        else
        {
            _reachedEndOfPath = false;
        }

        _seeker.transform.position = Vector2.MoveTowards(_seeker.transform.position, _path.vectorPath[_currentWayPoint], _speed * Time.deltaTime);

        float distance = Vector2.Distance(_seeker.transform.position, _path.vectorPath[_currentWayPoint]);

        if (distance < _nextWayPointDistance)
        {
            _currentWayPoint++;
        }

        _updateTimer += Time.deltaTime;
        if(_updateTimer >= 0.5f) {
            _updateTimer = 0.0f;
            UpdateFollowPlayerPath();
        }
    }

    private void UpdateFollowPlayerPath()
    {
        if (_seeker.IsDone())
            _seeker.StartPath(_seeker.transform.position, _playerPos.position, OnPathComplete);
    }

    private void OnPathComplete(Path p)
    {
        // Finished to calculate path
        if (!p.error)
        {
            _path = p;
            _currentWayPoint = 0;
        }
    }
}
