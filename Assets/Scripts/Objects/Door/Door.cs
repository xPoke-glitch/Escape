using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(SpriteRenderer))]
public class Door : MonoBehaviour
{
    #region events
    public static event Action OnDoorOpen;
    public static event Action OnDoorClose;
    #endregion
    public bool IsOpen { get; private set; }

    [Header("Connected Area")]
    [SerializeField]
    private GameObject areaGridObject;

    [Header("Sprites")]
    [SerializeField]
    private Sprite doorOpen;
    [SerializeField]
    private Sprite doorClose;

    private SpriteRenderer _spriteRenderer;

    public void Open()
    {
        IsOpen = true;
        _spriteRenderer.sprite = doorOpen;
        this.gameObject.layer = 0;
        areaGridObject.SetActive(true);

        OnDoorOpen?.Invoke();
    }

    public void Close()
    {
        IsOpen = false;
        _spriteRenderer.sprite = doorClose;
        this.gameObject.layer = 6;
        areaGridObject.SetActive(false);

        OnDoorClose?.Invoke();
    }

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        Close(); 
    }
}
