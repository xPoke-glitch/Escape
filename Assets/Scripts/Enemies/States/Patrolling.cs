using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class Patrolling : IState
{
    // External Attributes
    private Seeker _seeker;
    private Transform[] _patrolPoints;
    private float _speed;
    private float _nextWayPointDistance;

    // Internal Attributes
    private Path _path;
    private int _currentWayPoint = 0;
    private bool _reachedEndOfPath = false;
    private int _patrolIndex = 0;

    public Patrolling(Seeker seeker, Transform[] patrolPoints, float speed, float nextWayPointDistance)
    {
        _seeker = seeker;
        _patrolPoints = patrolPoints;
        _speed = speed;
        _nextWayPointDistance = nextWayPointDistance;

        _patrolIndex = 0;
    }

    public void OnEnter()
    {
        if(_patrolPoints.Length > 0)
        {
            _seeker.StartPath(_seeker.transform.position, GetNextPatrolPoint(), OnPathComplete);
        }
    }

    public void OnExit()
    {
        // Nothing for now
    }

    public void Tick()
    {
        if (_path == null)
            return;

        if(_currentWayPoint >= _path.vectorPath.Count)
        {
            _reachedEndOfPath = true;

            // Stay there if you have only one point
            if (_patrolPoints.Length == 1)
                return;

            if(_seeker.IsDone())
                _seeker.StartPath(_seeker.transform.position, GetNextPatrolPoint(), OnPathComplete);
            return;
        }
        else
        {
            _reachedEndOfPath = false;
        }

        _seeker.transform.position = Vector2.MoveTowards(_seeker.transform.position, _path.vectorPath[_currentWayPoint], _speed * Time.deltaTime);

        float distance = Vector2.Distance(_seeker.transform.position, _path.vectorPath[_currentWayPoint]);

        if(distance < _nextWayPointDistance)
        {
            _currentWayPoint++;
        }
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

    private Vector3 GetNextPatrolPoint()
    {
        Vector3 point = Vector3.zero;
        point = _patrolPoints[_patrolIndex].position;
        _patrolIndex = (_patrolIndex + 1) % _patrolPoints.Length;
        AstarPath.active.Scan();
        return point;
    }
}
