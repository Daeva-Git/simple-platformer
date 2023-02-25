using Unity.VisualScripting;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public Camera camera;

    public float maxSpeedMultiplier = 2;
    public float jumpHeight;

    private Rigidbody _rigidbody;
    public float speed;
    private float _currentSpeedMultiplier = 1;
    
    private Vector3 _temp;
    private bool _isGrounded;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }
    
    private void FixedUpdate()
    {
        UpdateSprint();
    }
    
    private void UpdateSprint()
    {
        if (GameManager.Instance.InputHandler.isSprinting)
        {
            _currentSpeedMultiplier += Time.fixedDeltaTime * 10;

            if (_currentSpeedMultiplier > maxSpeedMultiplier)
            {
                _currentSpeedMultiplier = maxSpeedMultiplier;
            }
        }
        else
        {
            _currentSpeedMultiplier = 1;
        }
    }
    

    private void Jump()
    {
        _isGrounded = false;
        _rigidbody.AddForce(Vector3.up * jumpHeight);
    }

    private void Move(Vector3 direction)
    {
        _rigidbody.AddForce(direction * speed);
    }

    private void MoveLeft()
    {
        Move(Vector3.back);
    }
    
    private void MoveRight()
    {
        Move(Vector3.forward);
    }
    
    private void OnEnable()
    {
        GameManager.Instance.InputHandler.OnSpacePressed += Jump;
        GameManager.Instance.InputHandler.OnRightArrowPressed += MoveRight;
        GameManager.Instance.InputHandler.OnLeftArrowPressed += MoveLeft;
    }

    private void OnDisable()
    {
        GameManager.Instance.InputHandler.OnSpacePressed -= Jump;
        GameManager.Instance.InputHandler.OnRightArrowPressed -= MoveRight;
        GameManager.Instance.InputHandler.OnLeftArrowPressed -= MoveLeft;
    }
}

