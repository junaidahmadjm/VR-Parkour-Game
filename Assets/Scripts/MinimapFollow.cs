using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinimapFollow : MonoBehaviour
{
    public Transform player; 
    public RectTransform playerMarker; 
    public Camera minimapCamera; 

    void LateUpdate()
    {
       
        Vector3 newMarkerPosition = new Vector3(player.position.x, player.position.z, 0);
       // Debug.Log("New Marker Position: " + newMarkerPosition);
        playerMarker.localPosition = newMarkerPosition;
        playerMarker.localEulerAngles = new Vector3(0, 0, -player.eulerAngles.y);
        Vector3 newCameraPosition = new Vector3(player.position.x, minimapCamera.transform.position.y, player.position.z);
       // Debug.Log("New Camera Position: " + newCameraPosition);
        minimapCamera.transform.position = newCameraPosition;
    }
}
