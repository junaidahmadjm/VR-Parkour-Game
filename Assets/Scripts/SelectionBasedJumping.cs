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

    private void OnEnable()
    {
        MoveAction.Enable();
    }
    private void OnDisable()
    {
        MoveAction.Disable();
    }

    private void Update()
    {

        RaycastHit Hit;
        if(Physics.Raycast(GameObjectGivingDirection.transform.position,GameObjectGivingDirection.transform.forward,out Hit,Mathf.Infinity,RayCollisionLayer))
        {
            Reticule.transform.position = Hit.point;
            Reticule.SetActive(true);
        }
        else
        {
            Reticule.SetActive(false);
        }

        if(MoveAction.WasPerformedThisFrame() && Reticule.activeSelf)
        {
            GameObjectToMove.transform.position = Reticule.transform.position;
        }
    }
}
