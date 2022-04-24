using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPPanel : MonoBehaviour
{
    [SerializeField]
    private GameObject HPBoxPrefab;
    [SerializeField]
    private Transform spawnLocation;
    [SerializeField]
    private int maxHPBox;

    private List<HPBox> _HPs;

    private void Awake()
    {
        _HPs = new List<HPBox>();
    }

    private void Start()
    {
        int maxHealth = FindObjectOfType<Player>().MaxHealth;
        for(int i=0; i<maxHealth; ++i)
        {
            AddHPBox();
        }
    }

    private void Update()
    {
        // Keep Number of Boxes updated based on MaxHealth
        int maxHealth = FindObjectOfType<Player>().MaxHealth;
        if (_HPs.Count != maxHealth)
        {
            int toAdd = maxHealth - _HPs.Count;
            for(int i=0; i < toAdd; ++i)
            {
                AddHPBox();
            }
        }

        // Keep updated health fill color
        int health = FindObjectOfType<Player>().Health;
        for(int i=health; i < _HPs.Count; ++i)
        {
            _HPs[i].EmptyBox();
        }
        
    }

    public void AddHPBox()
    {
        if (_HPs.Count + 1 > maxHPBox)
        {
            Debug.LogError("[HPPanel AddHPBox] Cannot add more HPBoxes - max hp boxes number: " + maxHPBox);
            return;
        }

        Vector3 pos = spawnLocation.position;
        pos.x = spawnLocation.position.x + (70 * _HPs.Count);
        GameObject obj = Instantiate(HPBoxPrefab, this.transform);
        obj.transform.position = pos;
        _HPs.Add(obj.GetComponent<HPBox>());
    }
}
