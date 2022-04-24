using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoDialogueTrigger : MonoBehaviour
{
    [Header("Ink JSON")]
    [SerializeField] private TextAsset inkJSON;

    private bool _isPlayerInRange;
    private bool _playOnce = false;

    private void Awake()
    {
        _isPlayerInRange = false;
    }

    private void Update()
    {
        if (_isPlayerInRange && !DialogueManager.Instance.IsDialoguePlaying && !_playOnce)
        {
            _playOnce = true;
            DialogueManager.Instance.EnterDialogueMode(inkJSON);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Player"))
        {
            _isPlayerInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Player"))
        {
            _isPlayerInRange = false;
        }
    }
}
