using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class PlayerAnimation : MonoBehaviour
{
    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (!DialogueManager.Instance.IsDialoguePlaying)
        {
            if (InputManager.Instance.IsMoving)
                _animator.SetBool("IsWalking", true);
            else
                _animator.SetBool("IsWalking", false);
        }
        else
        {
            _animator.SetBool("IsWalking", false); // reset
        }
    }
}
