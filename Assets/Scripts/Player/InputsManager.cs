using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    public delegate void DelegateMove(Vector2 vector);
    public static DelegateMove OnMoveDelegate;

    public delegate void DelegateShot();
    public static DelegateShot OnShotDelegate;
     
    public void OnMove(InputAction.CallbackContext ctx)
    {
        OnMoveDelegate?.Invoke(ctx.ReadValue<Vector2>());
    }

    public void OnShot(InputAction.CallbackContext ctx) 
    {
        switch (ctx.phase)
        { 
            case InputActionPhase.Started:
                OnShotDelegate?.Invoke();
                break; 
        }
    }
} 