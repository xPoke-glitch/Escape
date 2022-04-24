using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPBox : MonoBehaviour
{
    [SerializeField] private Image fill;

    private Color32 _defaultFillColor;

    private void Awake()
    {
        _defaultFillColor.r = 66;
        _defaultFillColor.g = 221;
        _defaultFillColor.b = 24;
        _defaultFillColor.a = 255;
        fill.color = _defaultFillColor;
    }

    public void EmptyBox()
    {
        fill.color = Color.black;
    }

    public void FillBox()
    {
        fill.color = _defaultFillColor;
    }
}
