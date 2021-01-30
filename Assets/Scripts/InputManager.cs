using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Interactions;

//Sers à définir l'odre d'exécution des scripts, -1 assure qu'il s'exécute avant les autres
[DefaultExecutionOrder(-1)]
public class InputManager : MonoBehaviour
{
    public static InputManager Instance;
    
    private Controller controller;

    public delegate void StartTouchEvent(Vector2 position, float time);
    public event StartTouchEvent OnStartTouch;
    
    public delegate void EndTouchEvent(Vector2 position, float time);
    public event EndTouchEvent OnEndTouch;
    
    public delegate void TapEvent();
    public event TapEvent OnTap;
    
    public delegate void ArrowPressedEvent(float value);
    public event ArrowPressedEvent OnArrowPressed;

    private Vector2 position;
    
    private void Awake()
    {
        if (Instance == null) Instance = this;
        else return;
        
        controller = new Controller();
    }

    void Start()
    {
        controller.Controls.TouchPress.performed += ctx => StartTouch(ctx);
        controller.Controls.TouchPress.canceled += ctx => EndTouch(ctx);
        controller.Controls.Tap.performed += ctx => Tap(ctx);

        controller.Controls.PcMovement.performed +=  ctx=> ArrowPressed(ctx);
    }

    private void ArrowPressed(InputAction.CallbackContext ctx)
    {
        OnArrowPressed?.Invoke(controller.Controls.PcMovement.ReadValue<float>());
    }

    private void StartTouch(InputAction.CallbackContext ctx)
    {
        OnStartTouch?.Invoke(controller.Controls.TouchPosition.ReadValue<Vector2>(),(float)ctx.startTime);
    }
    
    private void EndTouch(InputAction.CallbackContext ctx)
    {
        OnEndTouch?.Invoke(controller.Controls.TouchPosition.ReadValue<Vector2>(),(float)ctx.time);
    }
    
    private void Tap(InputAction.CallbackContext ctx)
    {
       OnTap?.Invoke();
    }

    
    private void OnEnable()
    {
        controller.Enable();
    }

    private void OnDisable()
    {
        controller.Disable();
    }
    
    
}
