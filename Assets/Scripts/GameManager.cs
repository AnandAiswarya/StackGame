using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private CubeSpawner[] spawners;
    private int spawnerIndex;
    private CubeSpawner currentSpawner;
    // public Text phaseDisplayText;
    private Touch theTouch;
    // private float timeTouchEnded;
    // private float displayTime = .5f;
    private void Awake()
    {
        spawners = FindObjectsOfType<CubeSpawner>();
    }


    public static event Action OnCubeSpawned = delegate {};
    // Update is called once per frame
    private void Update()
    {  if (Input.GetButtonDown("Fire1"))
        {
        //     theTouch = Input.GetTouch(0);
        // //     phaseDisplayText.text = theTouch.phase.ToString();

	    // //     if (theTouch.phase == TouchPhase.Ended)
	    // //     {
		// //         timeTouchEnded = Time.time;
	    // //     }
        // // }   

        // // else if (Time.time - timeTouchEnded > displayTime)
        // // {
	    // //     phaseDisplayText.text = “”;
        // // }
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

