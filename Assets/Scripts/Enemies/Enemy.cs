using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

[RequireComponent(typeof(Seeker), typeof(Rigidbody2D))]
public abstract class Enemy : MonoBehaviour
{
    [Header("Ranges")]
    public float CommunicationRange;
    public float TriggerRange;
    public float HitRange;

    [Header("AI Pathfinding")]
    [SerializeField]
    protected float speed = 1.0f;
    [SerializeField]
    protected float nextWayPointDistance = 3.0f;

    [Header("Physics")]
    [SerializeField]
    protected LayerMask playerLayerMask;

    protected Seeker _seeker;
    protected StateMachine _stateMachine;

    protected bool _isPlayerInTriggerRange = false;
    protected bool _isPlayerInHitRange = false;
    protected bool _isAlerted = false;
    protected bool _stop = false;

    protected abstract void SetStateMachine();

    public void DestroyEnemy()
    {
        Destroy(this.gameObject);
    }

    public void Alert()
    {
        _isAlerted = true;
    }

    protected virtual void Awake()
    {
        _seeker = GetComponent<Seeker>();
        _stateMachine = new StateMachine();
    }

    protected virtual void Start()
    {
        SetStateMachine();
    }

    protected virtual void Update()
    {
        _stateMachine.Tick();
    }

    private void OnEnable()
    {
        Player.OnGameOver += StopEnemy;
        Player.OnDamage += StopEnemy;
    }

    private void OnDisable()
    {
        Player.OnGameOver -= StopEnemy;
        Player.OnDamage -= StopEnemy;
    }

    private void StopEnemy()
    {
        _stop = true;
    }

    protected virtual void FixedUpdate()
    {
        // Trigger
        Collider2D col = Physics2D.OverlapCircle(this.transform.position, TriggerRange, playerLayerMask);
        if(col != null)
        {
            _isPlayerInTriggerRange = true;
        }
        else
        {
            _isPlayerInTriggerRange = false;
        }
        // Hit
        col = Physics2D.OverlapCircle(this.transform.position, HitRange, playerLayerMask);
        if (col != null)
        {
            _isPlayerInHitRange = true;
        }
        else
        {
            _isPlayerInHitRange = false;
        }
        // Communication
        if(CommunicationRange!=0 && _isPlayerInTriggerRange)
        {
            Collider2D[] cols = Physics2D.OverlapCircleAll(transform.position, CommunicationRange, (int)Mathf.Pow(2,gameObject.layer));
            Debug.Log(cols.Length+" "+gameObject.layer);
            foreach(Collider2D c in cols)
            {
                if(!c.gameObject.name.Equals(this.gameObject.name))
                {
                    c.GetComponent<Enemy>().Alert();
                    Debug.Log("[Enemy Update] Alerted -> " + c.gameObject.name);
                }   
            }
        }
    }
}
