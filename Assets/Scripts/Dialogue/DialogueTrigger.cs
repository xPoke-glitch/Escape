using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    [Header("Visual Cue")]
    [SerializeField] private GameObject visualCue;

    [Header("Ink JSON")]
    [SerializeField] private TextAsset inkJSON;

    private bool _isPlayerInRange;

    private void Awake()
    {
        _isPlayerInRange = false;
        visualCue.SetActive(false);
    }

    private void Update()
    {
        if (_isPlayerInRange && !DialogueManager.Instance.IsDialoguePlaying)
        {
            visualCue.SetActive(true);
            if (InputManager.Instance.GetInteractPressed())
            {
                DialogueManager.Instance.EnterDialogueMode(inkJSON);
            }
        }
        else
        {
            visualCue.SetActive(false);
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
