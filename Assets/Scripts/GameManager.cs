using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
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
        if (Input.GetButtonDown("Fire1"))
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
}
