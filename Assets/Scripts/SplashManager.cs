using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SplashManager : MonoBehaviour
{
    public GameObject StartObjects;
    public GameObject LoadingObject;
    private void OnEnable()
    {
        if (LoadingObject)
            LoadingObject.SetActive(false);
        if (StartObjects)
            StartObjects.SetActive(true);

        
    }
    public void SwitchToMainScene()
    {
        if (StartObjects)
            StartObjects.SetActive(false);

        if (LoadingObject)
            LoadingObject.SetActive(true);
    }
}
