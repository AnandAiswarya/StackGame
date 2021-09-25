using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{


    //public static event Action OnCubeSpawned = delegate {};
    // Update is called once per frame
    private void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            if(MovingCube.CurrentCube != null)
                MovingCube.CurrentCube.Stop();
            FindObjectOfType<CubeSpawner>().SpawnCube();
            //OnCubeSpawned();
        }
        
    }
}
