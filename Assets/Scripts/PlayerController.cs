using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;
using Vector3 = UnityEngine.Vector3;

public class PlayerController : MonoBehaviour
{
    private InputManager inputManager;
    private Camera cameraMain;
    
    private Rigidbody2D player;
    
    [SerializeField] float horizontalSpeed = 10;
    
    Vector3 movement = Vector3.zero;

    private void Awake()
    {
        inputManager = InputManager.Instance;
        player = gameObject.GetComponent<Rigidbody2D>();
        cameraMain = Camera.main;
    }

    private void OnEnable()
    {
        inputManager.OnStartTouch += CalculateDirection;
        inputManager.OnEndTouch += CancelMovement;
        inputManager.OnArrowPressed += Move;
    }

    
    private void OnDisable()
    {
        inputManager.OnStartTouch -= CalculateDirection;
        inputManager.OnEndTouch -= CancelMovement;
    }

    private void CalculateDirection(Vector2 screenPosition, float time)
    {
        float direction = 0;
        if (screenPosition.x < Screen.width / 2) direction = -1;
        else direction = 1;
        Move(direction);
    }
    
    private void Move(float direction)
    {
        movement.x = direction * horizontalSpeed ;
        player.velocity = movement;
    }
    
    private void CancelMovement(Vector2 position, float time)
    {
        player.velocity = Vector3.zero;
    }
}
