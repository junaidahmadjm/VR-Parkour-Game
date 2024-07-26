using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class SelectionBasedJumping : MonoBehaviour
{
    public GameObject GameObjectToMove;
    public GameObject GameObjectGivingDirection;
    public GameObject Reticule;
    public InputAction MoveAction;
    public LayerMask RayCollisionLayer;
    public float moveSpeed = 20f; 
    public LineRenderer lineRenderer; 

    private bool shouldMove = false;
    private Vector3 targetPosition;

    private void OnEnable()
    {
        MoveAction.Enable();
    }

    
    private void OnDisable()
    {
        MoveAction.Disable();
    }

    private void Start()
    {
       
        if (lineRenderer != null)
        {
            lineRenderer.startWidth = 0.01f; 
            lineRenderer.endWidth = 0.05f;  
            lineRenderer.positionCount = 2;
            lineRenderer.SetPosition(0, new Vector3(0, 0, 0));
            lineRenderer.SetPosition(1, new Vector3(5, 5, 5));

        }
    }

    private void Update()
    {
        RaycastHit hit;
        if (Physics.Raycast(GameObjectGivingDirection.transform.position, GameObjectGivingDirection.transform.forward, out hit, Mathf.Infinity, RayCollisionLayer))
        {
            Reticule.transform.position = hit.point;
            Reticule.SetActive(true);
            if (lineRenderer != null)
            {
                lineRenderer.SetPosition(0, GameObjectGivingDirection.transform.position);
                lineRenderer.SetPosition(1, Reticule.transform.position);
            }
        }
        else
        {
            Reticule.SetActive(false);
            if (lineRenderer != null)
            {
                lineRenderer.SetPosition(0, Vector3.zero);
                lineRenderer.SetPosition(1, Vector3.zero);
            }
        }

        if (MoveAction.WasPerformedThisFrame() && Reticule.activeSelf)
        {
            shouldMove = true;
            targetPosition = Reticule.transform.position;
        }
        if (shouldMove)
        {
            GameObjectToMove.transform.position = Vector3.Lerp(GameObjectToMove.transform.position, targetPosition, moveSpeed * Time.deltaTime);

            if (Vector3.Distance(GameObjectToMove.transform.position, targetPosition) < 0.01f)
            {
                GameObjectToMove.transform.position = targetPosition;
                shouldMove = false;
            }
        }
    }
}
