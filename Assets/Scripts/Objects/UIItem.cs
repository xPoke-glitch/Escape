using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIItem : MonoBehaviour
{
    [SerializeField]
    private Sprite icon;

    public Sprite GetIcon()
    {
        return icon;
    }
}
