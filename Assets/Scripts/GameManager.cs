using System;
using System.Collections;
using System.Collections.Generic;
using JMRSDK.InputModule;
using UnityEngine;

public class GameManager : MonoBehaviour,ISelectHandler, ISelectClickHandler
{
    private CubeSpawner[] spawners;
    private int spawnerIndex;
    private CubeSpawner currentSpawner;
    private void Awake()
    {
        spawners = FindObjectsOfType<CubeSpawner>();
    }


    public static event Action OnCubeSpawned = delegate {};
    // Update is called once per frame
    private void Update()
    {
        if (OnSelectClicked())
        {
            if(MovingCube.CurrentCube != null)
                MovingCube.CurrentCube.Stop();

            spawnerIndex = spawnerIndex == 0 ? 1 : 0;
            currentSpawner = spawners[spawnerIndex];
            currentSpawner.SpawnCube();
            //FindObjectOfType<CubeSpawner>().SpawnCube();
            OnCubeSpawned();
        }
        
    }

    private bool OnSelectClicked()
    {
        throw new NotImplementedException();
    }

    public void OnSelectDown(SelectEventData eventData)
    {
        throw new NotImplementedException();
    }

    public void OnSelectUp(SelectEventData eventData)
    {
        throw new NotImplementedException();
    }

    public void OnSelectClicked(SelectClickEventData eventData)
    {
        throw new NotImplementedException();
    }
}
