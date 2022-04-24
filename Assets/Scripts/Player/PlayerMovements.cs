using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovements : MonoBehaviour
{
    [SerializeField] private PlayerCollision playerCollision;

    [Header("Settings")]
    [SerializeField] private float walkSpeed;

    private void Update()
    {
        if (!DialogueManager.Instance.IsDialoguePlaying)
        {
            if (InputManager.Instance.MoveDirection.Equals(Vector2.right) && !playerCollision.RightCollision)
                transform.position += Time.deltaTime * walkSpeed * Vector3.right;
            if (InputManager.Instance.MoveDirection.Equals(Vector2.left) && !playerCollision.LeftCollision)
                transform.position += Time.deltaTime * walkSpeed * Vector3.left;
            if (InputManager.Instance.MoveDirection.Equals(Vector2.up) && !playerCollision.UpCollision)
                transform.position += Time.deltaTime * walkSpeed * Vector3.up;
            if (InputManager.Instance.MoveDirection.Equals(Vector2.down) && !playerCollision.DownCollision)
                transform.position += Time.deltaTime * walkSpeed * Vector3.down;
        }
    }

    private void OnEnable()
    {
        Player.OnDamage += StopMovement;
        Player.OnGameOver += StopMovement;
    }

    private void OnDisable()
    {
        Player.OnDamage -= StopMovement;
        Player.OnGameOver -= StopMovement;
    }

    private void StopMovement()
    {
        walkSpeed = 0;
    }
}
