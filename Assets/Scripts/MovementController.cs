using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MovementController : MonoBehaviour
{
    public InputActionProperty LeftControllerInput; 
    public InputActionProperty RightControllerInput;
    public InputActionProperty JumpInput;
    public float movementSpeed;
    public float JumpHeight = 2.0f;
    public float Gravity = -9.8f;
    public Transform xrOriginTransform; 

    private Vector3 leftControllerValue; 
    private Vector3 rightControllerValue;

    private CharacterController characterController;
    [SerializeField]
    private Vector3 Velocity;
    [SerializeField]
    private bool IsGrounded;

    public float Senstivity;

    public static MovementController Instance;
    private void OnEnable()
    {
        Instance = this;
    }
    private void Start()
    {
        LeftControllerInput.action.Enable();
        RightControllerInput.action.Enable();

        JumpInput.action.Enable();

        
        characterController = GetComponent<CharacterController>();

    }

    private void Update()
    {
        leftControllerValue = LeftControllerInput.action.ReadValue<Vector3>();
        rightControllerValue = RightControllerInput.action.ReadValue<Vector3>();

        Debug.Log("Left Controller value: " + leftControllerValue);
        Debug.Log("Right Controller value: " + rightControllerValue);


        Debug.Log("Left X Value: " + leftControllerValue.x);
        Debug.Log("Right X Value: " + rightControllerValue.x);

        MovePlayer(leftControllerValue);
        MovePlayer(rightControllerValue);

        HandleJump();
        ApplyGravity();
    }

    private void MovePlayer(Vector3 input)
    {
        if(input.magnitude < Senstivity)
        {
            return;
        }
        Vector3 moveDirection = Camera.main.transform.forward * Mathf.Abs(input.y);
        moveDirection.y = 0; 
        if (moveDirection.magnitude > 1f)
        {
            moveDirection.Normalize();
        }
        xrOriginTransform.Translate(moveDirection * movementSpeed * Time.deltaTime, Space.World);
    }

    void HandleJump()
    {
        IsGrounded = characterController.isGrounded;
        if(IsGrounded && Velocity.y <0)
        {
            Velocity.y = 0f;
        }
        if(IsGrounded && /*JumpInput.action.triggered*/ (Mathf.Abs(leftControllerValue.x) > 1.5f || Mathf.Abs(rightControllerValue.x) > 1.5f))
        {
            Velocity.y += Mathf.Sqrt(JumpHeight * -2f * Gravity);
        }
    }

    void ApplyGravity()
    {
        Velocity.y += Gravity * Time.deltaTime;
        characterController.Move(Velocity * Time.deltaTime);
    }
}
