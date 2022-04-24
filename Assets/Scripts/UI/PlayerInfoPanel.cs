using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInfoPanel : MonoBehaviour
{

    public bool IsMenuOpen { get; private set; }

    private Animator _animator;

    private void Awake()
    {
        IsMenuOpen = false;
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (InputManager.Instance.GetMenuPressed())
        {
            if (IsMenuOpen)
                _animator.SetTrigger("Close");
            else
                _animator.SetTrigger("Open");

            IsMenuOpen = !IsMenuOpen;
        }
    }

}
