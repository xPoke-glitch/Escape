using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class EnemyGFX : MonoBehaviour
{
    private Animator _animator;

    private Vector3 _prevPos;
    private Vector3 _newPos;
    private Vector3 _objVelocity;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _prevPos = this.transform.position;
        _newPos = this.transform.position;
    }

    private void Update()
    {
        if (_objVelocity.magnitude > 0.0f)
        {
            _animator.SetBool("IsWalking", true);
        }
        else
        {
            _animator.SetBool("IsWalking", false);
        }
    }

    private void FixedUpdate()
    {
        _newPos = transform.position;  // each frame track the new position
        _objVelocity = (_newPos - _prevPos) / Time.fixedDeltaTime;  // velocity = dist/time
        _prevPos = _newPos;  // update position for next frame calculation
    }
}
