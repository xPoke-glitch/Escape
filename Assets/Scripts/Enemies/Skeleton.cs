using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skeleton : Enemy
{
    [Header("Skeleton")]
    [SerializeField]
    private Transform[] patrolPoints;
    [SerializeField]
    private Transform guardingPoint;

    protected override void SetStateMachine()
    {
        // Implementing the state machine (States and Transitions)

        // States
        var patrolling = new Patrolling(_seeker, patrolPoints, speed, nextWayPointDistance);
        var following = new PlayerFollowing(_seeker, FindObjectOfType<Player>().transform, speed*2.5f, nextWayPointDistance);
        var attacking = new Attacking(FindObjectOfType<Player>(), this);
        var guarding = new Guarding(_seeker, new Transform[] { guardingPoint }, speed*2.5f, nextWayPointDistance);
        var empty = new EmptyState();

        // Transitions and Any-Transitions
        _stateMachine.AddTransition(patrolling, following, ()=> { return _isPlayerInTriggerRange; });
        _stateMachine.AddTransition(patrolling, guarding, () => {
            if (_isAlerted)
            {
                _isAlerted = false;
                return true;
            }
            else
                return false;
        });
        _stateMachine.AddTransition(patrolling, attacking, () => { return _isPlayerInHitRange; });
        _stateMachine.AddTransition(following, attacking, () => { return _isPlayerInHitRange; });
        _stateMachine.AddTransition(guarding, attacking, () => { return _isPlayerInHitRange; });
        _stateMachine.AddAnyTransition(empty, () => { return _stop; });

        // Set Initial State
        _stateMachine.SetState(patrolling);
    }
}
