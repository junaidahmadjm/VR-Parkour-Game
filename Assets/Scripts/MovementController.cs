using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MovementController : MonoBehaviour
{
    public InputActionProperty LeftControllerInput; 
    public InputActionProperty RightControllerInput; 

    public InputAction JumpAction;

    public float movementSpeed; 
    public float jumpForce = 5.0f; 
    public Transform xrOriginTransform; 

    private Vector3 leftControllerValue; 
    private Vector3 rightControllerValue; 

    public GameObject GameObjectToMove;
    public GameObject GameObjectGivingDir;
    private Rigidbody rb; 
    private bool isGrounded;
    private void OnEnable()
    {
        JumpAction.Enable();
    }

    private void Start()
    {
        
        LeftControllerInput.action.Enable();
        RightControllerInput.action.Enable();
        
       
        //rb = GameObjectToMove.GetComponent<Rigidbody>();
        //if (rb == null)
        //{
        //    Debug.LogError("Rigidbody component missing from GameObjectToMove.");
        //}
    }

    private void Update()
    {
       
        leftControllerValue = LeftControllerInput.action.ReadValue<Vector3>();
        rightControllerValue = RightControllerInput.action.ReadValue<Vector3>();

        Debug.Log("Left Controller value: " + leftControllerValue);
        Debug.Log("Right Controller value: " + rightControllerValue);

       
        MovePlayer(leftControllerValue);
        MovePlayer(rightControllerValue);

        //if (JumpAction.WasPressedThisFrame() && isGrounded && rb != null)
        //{
            
        //    rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        //    isGrounded = false; 
        //}
    }

    private void MovePlayer(Vector3 input)
    {
       
        Vector3 moveDirection = Camera.main.transform.forward * Mathf.Abs(input.y);
        moveDirection.y = 0; 

        
        if (moveDirection.magnitude > 1f)
        {
            moveDirection.Normalize();
        }

        
        xrOriginTransform.Translate(moveDirection * movementSpeed * Time.deltaTime, Space.World);
    }
    private void OnCollisionEnter(Collision collision)
    {
       
        //if (collision.gameObject.CompareTag("Ground"))
        //{
        //    isGrounded = true; 
        //}
    }

    private void OnDisable()
    {
        JumpAction.Disable();
    }
}
