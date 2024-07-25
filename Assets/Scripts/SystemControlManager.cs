using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class SystemControlManager : MonoBehaviour
{
    [Header("------[System Control Manager]------")]
    [Space(10)]

    [Header("------[Navigation Techniques]------")]
    public GameObject[] SelectionBasedJumpObjects;
    public GameObject[] FlyingObjects;

    [Header("------[Way Finding Techniques]------")]
    public GameObject[] PathVisualizationObjects;
    public GameObject[] MiniMapObjects;
    public GameObject[] CompassObjects;

    [Header("------[System Control Techniques]------")]
    public GameObject WayFindingTechniquesPanel;



    public void ActivatePathVisualization()
    {
        foreach (var item in PathVisualizationObjects)
        {
            if (item)
                item.SetActive(true);
        }
    }
    public void ActivateMinimap()
    {
        foreach (var item in MiniMapObjects)
        {
            if (item)
                item.SetActive(true);
        }
    }
    public void ActivateCompass()
    {
        foreach (var item in CompassObjects)
        {
            if (item)
                item.SetActive(true);
        }
    }
    public void ExitGame()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
            Application.Quit();
#endif
    }

}
