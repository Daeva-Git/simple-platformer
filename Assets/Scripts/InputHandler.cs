using System;
using UnityEngine;

public class InputHandler : MonoBehaviour
{
    
    public float vertical;
    public float horizontal;
    public bool isSprinting;
    public bool spacePressed;

    private void Update()
    {
        isSprinting = Input.GetKey(KeyCode.LeftShift);

        UpdateAxis();
        CheckSpacePressed();
        CheckArrowsPressed();
    }

    private void UpdateAxis()
    {
        vertical = Input.GetAxis("Vertical");
        horizontal = Input.GetAxis("Horizontal");
    }

    private void CheckSpacePressed()
    {
        spacePressed = Input.GetKeyDown(KeyCode.Space);
        
        if (!spacePressed) return;
        
        OnSpacePressed?.Invoke();
    }
    
    private void CheckArrowsPressed()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
            OnRightArrowPressed?.Invoke();
        if (Input.GetKey(KeyCode.RightArrow))
            OnLeftArrowPressed?.Invoke();
    }
    
    public delegate void SpaceAction();
    public delegate void RightArrowAction();
    public delegate void LeftArrowAction();

    public event SpaceAction OnSpacePressed;
    public event RightArrowAction OnRightArrowPressed;
    public event LeftArrowAction OnLeftArrowPressed;
}
