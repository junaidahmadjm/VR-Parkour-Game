using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckCollision : MonoBehaviour
{
    public GameObject Booster;
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Booster"))
        {
            Debug.Log("Colideerrrrr");
            if (MovementController.Instance)
            {
                MovementController.Instance.JumpHeight *= 1.5f;

                GameObject.Destroy(Booster);
            }

        }
    }

    //private void OnCollisionEnter(Collision collision)
    //{
    //    if (collision.gameObject.CompareTag("Booster"))
    //    {

    //        Debug.Log("Colideerrrrr");
    //        //if(MovementController.Instance)
    //        //{
    //        //    MovementController.Instance.JumpHeight *= 2;
    //        //}

    //    }
    //}
}
