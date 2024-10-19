using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    PlayerInput playerInput;
    InputAction moveInput;
    [SerializeField] private float moveSpeed = 5f;

    private void Start()
    {
        playerInput = GetComponent<PlayerInput>();
        moveInput = playerInput.actions.FindAction("Move");
    }

    private void Update()
    {
        MovePlayer();
    }

    void MovePlayer()
    {
        Vector2 direction = moveInput.ReadValue<Vector2>();
        transform.position += moveSpeed * Time.deltaTime * new Vector3(direction.x, 0,0 );
    }
}
